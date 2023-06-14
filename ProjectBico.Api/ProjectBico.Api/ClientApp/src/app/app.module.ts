import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BreakPointRegistry, FlexLayoutModule, FlexStyleBuilder, LayoutAlignStyleBuilder, LayoutStyleBuilder, PrintHook, StylesheetMap, StyleUtils } from '@angular/flex-layout';
import { MatAutocompleteModule, MatBadgeModule, MatBottomSheetModule, MatButtonModule, MatButtonToggleModule, MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule, MatDialogModule, MatDividerModule, MatExpansionModule, MatGridListModule, MatIconModule, MatInputModule, MatListModule, MatMenuModule, MatNativeDateModule, MatPaginatorModule, MatProgressBarModule, MatProgressSpinnerModule, MatRadioModule, MatRippleModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSlideToggleModule, MatSnackBarModule, MatSortModule, MatStepperModule, MatTableModule, MatTabsModule, MatToolbarModule, MatTooltipModule, MatTreeModule } from '@angular/material';
import { NgxMaskModule } from 'ngx-mask';
import { CommonModule, ViewportScroller } from '@angular/common';
import { MaterialModule } from './modules/material-module/material.module';
import { HeaderComponent } from './layout/header/header.component';
import { AboutComponent } from './layout/about/about.component';
import { filter, pairwise } from "rxjs/operators";
import { Event, Router, Scroll } from '@angular/router';
import { HeaderRoutingModule } from './layout/routing/header.routing.module';
import {AutocompleteLibModule} from 'angular-ng-autocomplete';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { PortalModule } from '@angular/cdk/portal';
import { A11yModule } from '@angular/cdk/a11y';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { HowToWorkComponent } from './layout/how-to-work/how-to-work.component';
import { LandingpageComponent } from './layout/landingpage/landingpage.component';
import { CardFancyComponent } from './layout/card-fancy/card-fancy.component';
import { CardFancyCategorysComponent } from './layout/card-fancy-categorys/card-fancy-categorys.component';
import { BlogComponent } from './layout/blog/blog.component';
import { ClipboardModule } from 'ngx-clipboard';
import { FooterComponent } from './layout/footer/footer.component';
import { LoginComponent } from './layout/login/login.component';
import { RegisterComponent } from './layout/register/register.component';
import { HomeComponent } from './layout/home/home.component';
import { JwtInterceptor } from './core/helpers/jwt.interceptor';
import { ErrorInterceptor } from './core/helpers/error.interceptor';
import { fakeBackendProvider } from './core/helpers/fake-backend';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AboutComponent,
    HowToWorkComponent,
    LandingpageComponent,
    CardFancyComponent,
    CardFancyCategorysComponent,
    BlogComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    CommonModule,
    AutocompleteLibModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatTableModule,
    FormsModule,
    HttpClientModule,
    FlexLayoutModule,
    MatDialogModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    HeaderRoutingModule,
    MatExpansionModule,
    A11yModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    PortalModule,
    ScrollingModule,
    ClipboardModule,
    ToastrModule.forRoot({
      timeOut: 1000,
      positionClass: 'toast-bottom-right'
    }),
    NgxMaskModule.forRoot(),
  ],
  providers: [
    PrintHook,
    StyleUtils,
    StyleSheet,
    StylesheetMap,
    LayoutAlignStyleBuilder,
    LayoutStyleBuilder,
    FlexStyleBuilder,
    BreakPointRegistry,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

    // provider used to create fake backend
    fakeBackendProvider
  ],
  exports: [
    AppComponent,
  ],
  bootstrap: [AppComponent],
  entryComponents: []
})
export class AppModule {
constructor(private router: Router, private viewportScroller: ViewportScroller) {
  this.handleScrollOnNavigation();
}

private handleScrollOnNavigation(): void {
  this.router.events.pipe(
    filter((e: Event): e is Scroll => e instanceof Scroll),
    pairwise()
  ).subscribe((e: Scroll[]) => {
    const previous = e[0];
    const current = e[1];
    if (current.position) {
      this.viewportScroller.scrollToPosition(current.position);
    } else if (this.getBaseRoute(previous.routerEvent.urlAfterRedirects) !== this.getBaseRoute(current.routerEvent.urlAfterRedirects)) {
      this.viewportScroller.scrollToPosition([0, 0]);
    }
  });
}

  private getBaseRoute(url: string): string {
    return url.split('?')[0];
  }
}
