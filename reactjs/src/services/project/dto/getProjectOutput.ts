import EmployeeModel from '../../../models/WebAfricaModels/EmployeeModel';
import Employee from '../../../scenes/Employees';

export default class GetProjectOutput {
  name!: string;
  startdate!: Date;
  enddate: Date | null | undefined;
  cost!: number;
  totalCost!: number;
  employees!: EmployeeModel[];
  id!: number;
}
