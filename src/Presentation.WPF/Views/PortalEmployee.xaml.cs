﻿using ClosedXML.Excel;
using Core.DTOs;
using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using Domain.Primitives;
using Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.WPF.Views
{
    public partial class PortalEmployee : Window
    {
        private readonly IArlRepository _arlRepository;
        private readonly IPensionRepository _pensionRepository;
        private readonly IEpsRepository _epsRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;

        public PortalEmployee(IArlRepository arlRepository, IPensionRepository pensionRepository, IEpsRepository epsRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            HideFields();
            _arlRepository = arlRepository;
            _pensionRepository = pensionRepository;
            _epsRepository = epsRepository;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _serviceProvider = serviceProvider;

            Loaded += LoginWindow_Loaded;
        }

        private async void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private void HideFields()
        {
            TitleDeduction.Visibility = Visibility.Collapsed;
            DescEpsCompany.Visibility = Visibility.Collapsed;
            DescHealthCompany.Visibility = Visibility.Collapsed;
            DescEpsEmployee.Visibility = Visibility.Collapsed;
            DescHealthEmployee.Visibility = Visibility.Collapsed;
            ValueEpsCompany.Visibility = Visibility.Collapsed;
            ValueHealthCompany.Visibility = Visibility.Collapsed;
            ValueEpsEmployee.Visibility = Visibility.Collapsed;
            ValueHealthEmployee.Visibility = Visibility.Collapsed;
            DescSalaryFinal.Visibility = Visibility.Collapsed;
            ValueSalaryFinal.Visibility = Visibility.Collapsed;
        }

        private async Task LoadDataAsync()
        {
            try
            {
                List<Arl> arlRequest = await _arlRepository.GetAll();
                List<Pension> pensionRequest = await _pensionRepository.GetAll();
                List<Eps> epsRequest = await _epsRepository.GetAll();
                List<Employee> employeeRequest = await _employeeRepository.GetAll();

                var arls = arlRequest.Select(x => new ArlDto(
                        x.Id,
                        x.Name
                 )).ToList();

                var pensions = pensionRequest.Select(x => new PensionDto(
                      x.Id,
                      x.Name
               )).ToList();

                var epss = epsRequest.Select(x => new EpsDto(
                      x.Id,
                      x.Name
               )).ToList();

                var employees = employeeRequest.Select(x => new EmployeeDto(
                    x.Id.Value,
                    x.Name,
                    x.Cedula,
                    x.BloodType,
                    x.Phone.Value,
                    x.Arl.Name,
                    x.ArlId,
                    x.Eps.Name,
                    x.EpsId,
                    x.Pension.Name,
                    x.PensionId,
                    x.Salary
                )).ToList();

                ArlList.ItemsSource = arls;
                ArlList.DisplayMemberPath = "Name";
                ArlList.SelectedValuePath = "ArlId";

                PensionList.ItemsSource = pensions;
                PensionList.DisplayMemberPath = "Name";
                PensionList.SelectedValuePath = "PensionId";

                EpsList.ItemsSource = epss;
                EpsList.DisplayMemberPath = "Name";
                EpsList.SelectedValuePath = "EpsId";

                MyDataGrid.ItemsSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalaryField_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SalaryField.Text))
            {
                TitleDeduction.Visibility = Visibility.Visible;
                DescEpsCompany.Visibility = Visibility.Visible;
                DescHealthCompany.Visibility = Visibility.Visible;
                DescEpsEmployee.Visibility = Visibility.Visible;
                DescHealthEmployee.Visibility = Visibility.Visible;
                ValueEpsCompany.Visibility = Visibility.Visible;
                ValueHealthCompany.Visibility = Visibility.Visible;
                ValueEpsEmployee.Visibility = Visibility.Visible;
                ValueHealthEmployee.Visibility = Visibility.Visible;
                DescSalaryFinal.Visibility = Visibility.Visible;
                ValueSalaryFinal.Visibility = Visibility.Visible;

                if (decimal.TryParse(SalaryField.Text, out decimal salary))
                {
                    ValueEpsCompany.Content = $"{salary * 0.085m:C0}";
                    ValueEpsEmployee.Content = $"{salary * 0.04m:C0}";
                    ValueHealthCompany.Content = $"{salary * 0.085m:C0}";
                    ValueHealthEmployee.Content = $"{salary * 0.04m:C0}";
                    ValueSalaryFinal.Content = $"{salary * 0.92m:C0}";
                }
                else
                {
                    ValueEpsCompany.Content = "No válido";
                    ValueEpsEmployee.Content = "No válido";
                    ValueHealthCompany.Content = "No válido";
                    ValueHealthEmployee.Content = "No válido";
                    ValueSalaryFinal.Content = "No válido";
                }
            }
            else
            {
                HideFields();
            }
        }

        private async Task UpdateEmployeeGrid()
        {
            try
            {
                List<Employee> employeeRequest = await _employeeRepository.GetAll();

                var employees = employeeRequest.Select(x => new EmployeeDto(
                    x.Id.Value,
                    x.Name,
                    x.Cedula,
                    x.BloodType,
                    x.Phone.Value,
                    x.Arl.Name,
                    x.ArlId,
                    x.Eps.Name,
                    x.EpsId,
                    x.Pension.Name,
                    x.PensionId,
                    x.Salary
                )).ToList();

                MyDataGrid.ItemsSource = employees;

                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla de empleados: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ClearFormFields()
        {
            NameField.Text = string.Empty;
            IdentificationField.Text = string.Empty;
            BloodTypeField.Text = string.Empty;
            PhoneField.Text = string.Empty;
            SalaryField.Text = string.Empty;

            ArlList.SelectedIndex = -1;
            EpsList.SelectedIndex = -1;
            PensionList.SelectedIndex = -1;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameField.Text) ||
                string.IsNullOrWhiteSpace(IdentificationField.Text) ||
                string.IsNullOrWhiteSpace(BloodTypeField.Text) ||
                string.IsNullOrWhiteSpace(PhoneField.Text) ||
                string.IsNullOrWhiteSpace(SalaryField.Text) ||
                !decimal.TryParse(SalaryField.Text, out decimal salary))
            {
                MessageBox.Show("Por favor complete todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string name = NameField.Text;
            string cedula = IdentificationField.Text;
            string bloodType = BloodTypeField.Text;
            string phone = PhoneField.Text;
            Guid arlId = (Guid)ArlList.SelectedValue;
            Guid epsId = (Guid)EpsList.SelectedValue;
            Guid pensionId = (Guid)PensionList.SelectedValue;

            if (await _employeeRepository.GetByIdentification(cedula))
            {
                MessageBox.Show("La cedula ya ha sido registrada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Regex.IsMatch(cedula, @"^\d+$"))
            {
                MessageBox.Show("La cédula debe contener solo números.", "Formato incorrecto", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Regex.IsMatch(bloodType, @"^(A|B|AB|O)[+-]$"))
            {
                MessageBox.Show("El tipo de sangre debe ser A+, A-, B+, B-, AB+, AB-, O+ u O-.", "Formato incorrecto", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PhoneNumber.Create(phone) is not PhoneNumber phoneNumber)
            {
                MessageBox.Show("El número de teléfono no es válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Employee employee = new(
                new EmployeeId(Guid.NewGuid()),
                name,
                cedula,
                bloodType,
                phoneNumber,
                arlId,
                epsId,
                pensionId,
                salary,
                DateTime.Now
            );

            try
            {
                await _employeeRepository.Add(employee);
                await _unitOfWork.SaveChangesAsync();

                await UpdateEmployeeGrid();

                MessageBox.Show("Empleado creado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem is EmployeeDto selectedEmployee)
            {
                NameField.Text = selectedEmployee.Name;
                IdentificationField.Text = selectedEmployee.Identification;
                BloodTypeField.Text = selectedEmployee.BloodType;
                PhoneField.Text = selectedEmployee.Phone;
                SalaryField.Text = $"{selectedEmployee.Salary:0}";

                ArlList.SelectedValue = selectedEmployee.ArlId;
                EpsList.SelectedValue = selectedEmployee.EpsId;
                PensionList.SelectedValue = selectedEmployee.PensionId;
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MyDataGrid.SelectedItem is EmployeeDto selectedEmployee)
            {
                // Confirmar la eliminación
                var result = MessageBox.Show($"¿Estás seguro de que deseas eliminar a {selectedEmployee.Name}?",
                                             "Confirmar eliminación",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Guid employeeId = selectedEmployee.EmployeeId;

                        Employee? employee = await _employeeRepository.GetByIdAsync(new EmployeeId(employeeId));

                        if (employee is null)
                        {
                            MessageBox.Show($"Ocurrió un error al buscar el id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        _employeeRepository.Delete(employee);
                        await _unitOfWork.SaveChangesAsync();

                        await UpdateEmployeeGrid();

                        MessageBox.Show("Empleado eliminado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un empleado para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (MyDataGrid.SelectedItem is EmployeeDto selectedEmployee)
            {
                // Confirmar la eliminación
                var result = MessageBox.Show($"¿Estás seguro de que deseas actualizar a {selectedEmployee.Name}?",
                                             "Confirmar eliminación",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Guid employeeId = selectedEmployee.EmployeeId;

                        Employee? employee = await _employeeRepository.GetByIdAsync(new EmployeeId(employeeId));

                        if (employee is null)
                        {
                            MessageBox.Show($"Ocurrió un error al buscar el id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if (PhoneNumber.Create(PhoneField.Text) is not PhoneNumber phoneNumber)
                        {
                            MessageBox.Show("El número de teléfono no es válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        employee.Name = NameField.Text;
                        employee.EpsId = (Guid)EpsList.SelectedValue;
                        employee.ArlId = (Guid)ArlList.SelectedValue;
                        employee.PensionId = (Guid)PensionList.SelectedValue;
                        employee.Cedula = IdentificationField.Text;
                        employee.BloodType = BloodTypeField.Text;
                        employee.Phone = phoneNumber;
                        employee.Salary = decimal.Parse(SalaryField.Text);

                        _employeeRepository.Update(employee);

                        await _unitOfWork.SaveChangesAsync();

                        await UpdateEmployeeGrid();

                        MessageBox.Show("Empleado actualizado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al editar el empleado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un empleado para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DownloadExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Empleados");

                worksheet.Cell(1, 1).Value = "Nombre";
                worksheet.Cell(1, 2).Value = "Cédula";
                worksheet.Cell(1, 3).Value = "T. de Sangre";
                worksheet.Cell(1, 4).Value = "Teléfono";
                worksheet.Cell(1, 5).Value = "ARL";
                worksheet.Cell(1, 6).Value = "EPS";
                worksheet.Cell(1, 7).Value = "Pensión";
                worksheet.Cell(1, 8).Value = "Salario";

                var headerRange = worksheet.Range("A1:H1");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                if (MyDataGrid.ItemsSource is List<EmployeeDto> employees)
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = employees[i].Name;
                        worksheet.Cell(i + 2, 2).Value = employees[i].Identification;
                        worksheet.Cell(i + 2, 3).Value = employees[i].BloodType;
                        worksheet.Cell(i + 2, 4).Value = employees[i].Phone;
                        worksheet.Cell(i + 2, 5).Value = employees[i].ArlName;
                        worksheet.Cell(i + 2, 6).Value = employees[i].EpsName;
                        worksheet.Cell(i + 2, 7).Value = employees[i].PensionName;
                        worksheet.Cell(i + 2, 8).Value = employees[i].Salary;

                        worksheet.Range(i + 2, 1, i + 2, 8).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Range(i + 2, 1, i + 2, 8).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    }
                }

                worksheet.Columns().AdjustToContents();

                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filePath = Path.Combine(desktopPath, "Empleados.xlsx");
                workbook.SaveAs(filePath);

                MessageBox.Show("Archivo Excel generado exitosamente en el escritorio.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            this.Close();
        }
    }
}

