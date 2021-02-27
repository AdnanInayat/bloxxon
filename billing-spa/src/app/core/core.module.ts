import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { DataService } from './services/data.service';

@NgModule({
  declarations: [],
  providers: [DataService],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
