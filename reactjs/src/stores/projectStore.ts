import { action, observable } from 'mobx';

import CreateProjectInput from '../services/project/dto/createProjectInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllProjectOutput } from '../services/project/dto/getAllProjectOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedProjectResultRequestDto } from '../services/project/dto/PagedProjectResultRequestDto';
import ProjectModel from '../models/WebAfricaModels/ProjectModel';
import UpdateProjectInput from '../services/project/dto/updateProjectInput';
import projectService from '../services/project/projectService';
import JobTitleModel from '../models/WebAfricaModels/JobTitleModel';

class ProjectStore {
  @observable projects!: PagedResultDto<GetAllProjectOutput>;
  @observable projectModel: ProjectModel = new ProjectModel();

  @action
  async create(createProjectInput: CreateProjectInput) {
    await projectService.create(createProjectInput);
  }

  @action
  async createProject() {
    this.projectModel = {
      name: "string",
      startdate: new Date(),
      enddate: undefined,
      cost: 0,
      id: 0,
    };
  }

  @action
  async update(updateProjectInput: UpdateProjectInput) {
    let result = await projectService.update(updateProjectInput);

    this.projects.items = this.projects.items.map((x: GetAllProjectOutput) => {
      if (x.id === updateProjectInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await projectService.delete(entityDto);
    this.projects.items = this.projects.items.filter((x: GetAllProjectOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await projectService.get(entityDto);
    this.projectModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedProjectResultRequestDto) {
    let result = await projectService.getAll(pagedFilterAndSortedRequest);
    this.projects = result;
  }
}

export default ProjectStore;
