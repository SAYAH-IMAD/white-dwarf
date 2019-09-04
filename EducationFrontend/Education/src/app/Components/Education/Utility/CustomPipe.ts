import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'current' })
export class Current implements PipeTransform {
    transform(value: boolean): string {
        return value === true ? 'Current' : 'Not Current';
    };
}
