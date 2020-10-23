import JobTitleModel from '../../../models/WebAfricaModels/JobTitleModel';

export interface GetAllEmployeeOutput {
  name: string;
  surname: string;
  jobTitleId: number;
  id: number;
  jobTitle: JobTitleModel;
  dateOfBirth: Date;
}
