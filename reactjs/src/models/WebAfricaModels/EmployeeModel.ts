import JobTitleModel from './JobTitleModel';

class EmployeeModel {
  name!: string;
  surname!: string;
  jobTitleId!: number;
  jobTitle!: JobTitleModel;
  dateOfBirth!: Date;
  id!: number;
}

export default EmployeeModel;
