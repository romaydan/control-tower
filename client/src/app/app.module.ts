import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NotificationListComponent } from './components/notification-list/notification-list.component';
import { PlaneBoardComponent } from './components/plane-board/plane-board.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashBoardComponent } from './components/dash-board/dash-board.component';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FacilityComponent } from './components/facility/facility.component';
import { FacilityListComponent } from './components/facility-list/facility-list.component';
import { MatCardModule } from '@angular/material/card';
import { TitleComponent } from './components/title/title.component';
import { PascalToRegularPipe } from './pipe/pascalToRegularPipe';
import { PlaneAdditionalInfoPipe } from './pipe/planeAdditionalInfoPipe';
import {CdkTableModule} from '@angular/cdk/table';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    NotificationListComponent,
    PlaneBoardComponent,
    DashBoardComponent,
    FacilityComponent,
    FacilityListComponent,
    TitleComponent,
    PascalToRegularPipe,
    PlaneAdditionalInfoPipe
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    MatDividerModule,
    MatButtonModule,
    MatListModule,
    MatTableModule,
    MatCardModule,
    MatSlideToggleModule,
    CdkTableModule,
    MatInputModule

  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
