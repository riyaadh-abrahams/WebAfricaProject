import { List } from 'antd';
import Employee from '../../scenes/Employees';
import EmployeeModel from './EmployeeModel';

class ProjectModel {
  name!: string;
  startdate!: Date;
  enddate: Date | null | undefined;
  cost!: number;
  totalCost!: number;
  employees!: EmployeeModel[]
  id!: number;
}

export default ProjectModel;
