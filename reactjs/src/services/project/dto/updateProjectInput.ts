import EmployeeModel from '../../../models/WebAfricaModels/EmployeeModel';
import Employee from '../../../scenes/Employees';

export default interface UpdateProjectInput {
  name: string;
  startdate: Date;
  enddate: Date | undefined;
  cost: number;
  id: number;
  totalCost: number;
  employees: EmployeeModel[];
}
