import { List } from 'antd';
import EmployeeModel from '../../../models/WebAfricaModels/EmployeeModel';
import Employee from '../../../scenes/Employees';

export interface GetAllProjectOutput {
  name: string;
  startdate: Date;
  enddate: Date;
  cost: number;
  totalCost: number;
  employees: EmployeeModel[]
  id: number;
  
}
