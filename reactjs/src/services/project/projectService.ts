import CreateProjectInput from './dto/createProjectInput';
import CreateProjectOutput from './dto/createProjectOutput';
import { EntityDto } from '../../services/dto/entityDto';
import { GetAllProjectOutput } from './dto/getAllProjectOutput';
import GetProjectOutput from './dto/getProjectOutput';
import { PagedResultDto } from '../../services/dto/pagedResultDto';
import {PagedProjectResultRequestDto} from './dto/PagedProjectResultRequestDto';
import UpdateProjectInput from './dto/updateProjectInput';
import UpdateProjectOutput from './dto/updateProjectOutput';
import http from '../httpService';

class ProjectService {
  public async create(createProjectInput: CreateProjectInput): Promise<CreateProjectOutput> {
    let result = await http.post('api/services/app/ProjectService/Create', createProjectInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/ProjectService/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetProjectOutput> {
    let result = await http.get('api/services/app/ProjectService/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedProjectResultRequestDto): Promise<PagedResultDto<GetAllProjectOutput>> {
    let result = await http.get('api/services/app/ProjectService/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateProjectInput: UpdateProjectInput): Promise<UpdateProjectOutput> {
    let result = await http.put('api/services/app/ProjectService/Update', updateProjectInput);
    return result.data.result;
  }
}

export default new ProjectService();
