import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedProjectResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
