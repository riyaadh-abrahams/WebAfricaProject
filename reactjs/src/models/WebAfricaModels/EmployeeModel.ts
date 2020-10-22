import JobTitleModel from './JobTitleModel';

class EmployeeModel {
  name!: string;
  surname!: string;
  jobTitleId!: number;
  jobTitle!: JobTitleModel;
  id!: number;
}

export default EmployeeModel;
