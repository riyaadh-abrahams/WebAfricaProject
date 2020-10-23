import { action, observable } from 'mobx';

import CreateJobTitleInput from '../services/jobTitle/dto/createJobTitleInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllJobTitleOutput } from '../services/jobTitle/dto/getAllJobTitleOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedJobTitleResultRequestDto } from '../services/jobTitle/dto/PagedJobTitleResultRequestDto';
import JobTitleModel from '../models/WebAfricaModels/JobTitleModel';
import UpdateJobTitleInput from '../services/jobTitle/dto/updateJobTitleInput';
import jobTitleService from '../services/jobTitle/jobTitleService';

class JobTitleStore {
  @observable jobTitles!: PagedResultDto<GetAllJobTitleOutput>;
  @observable jobTitleModel: JobTitleModel = new JobTitleModel();

  @action
  async create(createJobTitleInput: CreateJobTitleInput) {
    await jobTitleService.create(createJobTitleInput);
  }

  @action
  async createJobTitle() {
    this.jobTitleModel = {
      jobTitleLabel: '',
      extraProjectCost: 0,
      id: 0,
    };
  }

  @action
  async update(updateJobTitleInput: UpdateJobTitleInput) {
    let result = await jobTitleService.update(updateJobTitleInput);

    this.jobTitles.items = this.jobTitles.items.map((x: GetAllJobTitleOutput) => {
      if (x.id === updateJobTitleInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await jobTitleService.delete(entityDto);
    this.jobTitles.items = this.jobTitles.items.filter((x: GetAllJobTitleOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await jobTitleService.get(entityDto);
    this.jobTitleModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedJobTitleResultRequestDto) {
    let result = await jobTitleService.getAll(pagedFilterAndSortedRequest);
    this.jobTitles = result;
  }
}

export default JobTitleStore;
