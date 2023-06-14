import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  name = '';
  reactiveForm: FormGroup;

  public placeholder: string = 'O que você precisa?';
  public keyword = 'name';
  public historyHeading: string = 'Selecionados Recentementes';

  public jobsReactive = ['Instalação de torneira',
    'Consertar ar-condicionado',
    'Instalação de tomada e interruptor',
    'Instalação de ventilador de teto',
    'Instalação de luminária',
    'Instalação de disjuntor',
    'Conserto de persianas',
    'Higienização de estofados',
    'Reparar piso ou revestimento',
    'Pintura externa',
    'Pintura interna (parede e teto)',
    'Limpeza de ar-condicionado',
    'Instalação de persiana e cortina',
    'Desentupir vaso sanitário',
    'Instalação de piso cerâmico',
    'Instalação de suporte de TV',
    'Instalação de chuveiro elétrico',
    'Instalação de coifa e depurador',
    'Pintura de portão e grade',
    'Instalação de ar-condicionado',
    'Pré-instalação de ar-condicionado',
    'Gesseiro (Pequenos reparos)',
    'Marido de Aluguel',
    'Eletricista',
    'Desinstalação de ar-condicionado',
    'Instalação de máquina de lavar louça',
    'Instalação de máquina de lavar roupa',
    'Consertar vazamento',
    'Pintura de portas e janelas',
    'Manutenção de ar-condicionado',
    'Montador de móveis',
    'Bombeiro hidráulico',
    'Instalação de revestimento na parede',
    'Instalação de piso porcelanato'];

  constructor(private _fb: FormBuilder) {
    this.reactiveForm = _fb.group({
      name: [{ value: '', disabled: false }, Validators.required]
    });
  }

  ngOnInit() {
  }

  submitReactiveForm() {
    if (this.reactiveForm.valid) {
      console.log(this.reactiveForm.value);
    }
  }
}
