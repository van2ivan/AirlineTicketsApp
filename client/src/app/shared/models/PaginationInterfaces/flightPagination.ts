import { IFlight } from '../EntitiyInterfaces/flight';

export interface IFlightPagination {
  pageIndex: number
  pageSize: number
  count: number
  data: IFlight[]
}
