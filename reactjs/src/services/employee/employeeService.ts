import CreateEmployeeInput from './dto/createEmployeeInput';
import CreateEmployeeOutput from './dto/createEmployeeOutput';
import { EntityDto } from '../../services/dto/entityDto';
import { GetAllEmployeeOutput } from './dto/getAllEmployeeOutput';
import GetEmployeeOutput from './dto/getEmployeeOutput';
import { PagedResultDto } from '../../services/dto/pagedResultDto';
import {PagedEmployeeResultRequestDto} from './dto/PagedEmployeeResultRequestDto';
import UpdateEmployeeInput from './dto/updateEmployeeInput';
import UpdateEmployeeOutput from './dto/updateEmployeeOutput';
import http from '../httpService';

class EmployeeService {
  public async create(createEmployeeInput: CreateEmployeeInput): Promise<CreateEmployeeOutput> {
    let result = await http.post('api/services/app/EmployeeService/Create', createEmployeeInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/EmployeeService/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetEmployeeOutput> {
    let result = await http.get('api/services/app/EmployeeService/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedEmployeeResultRequestDto): Promise<PagedResultDto<GetAllEmployeeOutput>> {
    let result = await http.get('api/services/app/EmployeeService/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateEmployeeInput: UpdateEmployeeInput): Promise<UpdateEmployeeOutput> {
    let result = await http.put('api/services/app/EmployeeService/Update', updateEmployeeInput);
    return result.data.result;
  }
}

export default new EmployeeService();
