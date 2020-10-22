import JobTitleModel from '../../../models/WebAfricaModels/JobTitleModel';

export default class GetEmployeeOutput {
  name!: string;
  surname!: string;
  jobTitleId!: number;
  jobTitle!: JobTitleModel;
  id!: number;
}
