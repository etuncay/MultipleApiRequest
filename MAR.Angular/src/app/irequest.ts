import {RequestMethod} from './request-method.enum';
import {IKeyValue} from './ikey-value';

export interface IRequest {
  name: string;
  resource: string;
  method: RequestMethod;
  data: IKeyValue[];
}
