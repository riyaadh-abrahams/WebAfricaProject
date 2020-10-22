import { action, observable } from 'mobx';

import CreateEmployeeInput from '../services/employee/dto/createEmployeeInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllEmployeeOutput } from '../services/employee/dto/getAllEmployeeOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedEmployeeResultRequestDto } from '../services/employee/dto/PagedEmployeeResultRequestDto';
import EmployeeModel from '../models/WebAfricaModels/EmployeeModel';
import UpdateEmployeeInput from '../services/employee/dto/updateEmployeeInput';
import employeeService from '../services/employee/employeeService';

class EmployeeStore {
  @observable employees!: PagedResultDto<GetAllEmployeeOutput>;
  @observable employeeModel: EmployeeModel = new EmployeeModel();

  @action
  async create(createEmployeeInput: CreateEmployeeInput) {
    await employeeService.create(createEmployeeInput);
  }

  @action
  async createEmployee() {
    this.employeeModel = {
      id: 0,
      name: '',
      surname: '',
      jobTitleId: 0
    };
  }

  @action
  async update(updateEmployeeInput: UpdateEmployeeInput) {
    let result = await employeeService.update(updateEmployeeInput);

    this.employees.items = this.employees.items.map((x: GetAllEmployeeOutput) => {
      if (x.id === updateEmployeeInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await employeeService.delete(entityDto);
    this.employees.items = this.employees.items.filter((x: GetAllEmployeeOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await employeeService.get(entityDto);
    this.employeeModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedEmployeeResultRequestDto) {
    let result = await employeeService.getAll(pagedFilterAndSortedRequest);
    this.employees = result;
  }
}

export default EmployeeStore;
