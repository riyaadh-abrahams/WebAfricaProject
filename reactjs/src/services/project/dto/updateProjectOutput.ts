import EmployeeModel from '../../../models/WebAfricaModels/EmployeeModel';
import Employee from '../../../scenes/Employees';

export default interface UpdateProjectOutput {
  name: string;
  startdate: Date;
  enddate: Date;
  cost: number;
  id: number;
  totalCost: number;
  employees: EmployeeModel[]
}
