import { ModuleWithProviders, NgModule} from "@angular/core";
import { MatIconRegistry } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ReactiveFormsModule } from "@angular/forms";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';
import { MatTreeModule } from "@angular/material/tree";
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule} from '@angular/material/tooltip';
import {MatRadioModule} from '@angular/material/radio';

@NgModule({
    imports: [
        MatTabsModule,
        MatIconModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatCardModule,
        MatToolbarModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        MatTreeModule,
        MatMenuModule,
        MatTooltipModule,
        MatRadioModule
    ],
    exports: [
        MatTabsModule,
        MatIconModule,
        MatInputModule,
        MatButtonModule,
        MatCardModule,
        MatCheckboxModule,
        MatSelectModule,
        MatToolbarModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        MatTreeModule,
        MatMenuModule,
        MatTooltipModule,
        MatRadioModule
    ],
    providers: [
    ]
})
export class MaterialModule {
    constructor(public matIconRegistry: MatIconRegistry) {
    }

    static forRoot(): ModuleWithProviders<MaterialModule> {
        return {
            ngModule: MaterialModule,
            providers: [MatIconRegistry]
        };
    }
}
