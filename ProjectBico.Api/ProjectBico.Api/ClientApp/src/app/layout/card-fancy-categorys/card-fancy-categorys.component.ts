import { Component, OnInit } from '@angular/core';

export interface Section {
  photo: string;
  name: string;
}

@Component({
  selector: 'app-card-fancy-categorys',
  templateUrl: './card-fancy-categorys.component.html',
  styleUrls: ['./card-fancy-categorys.component.scss']
})

export class CardFancyCategorysComponent implements OnInit {

  selected = false;

  // onSelectCard() {
  //   this.selected = !this.selected;
  // }

  constructor() { }

  ngOnInit() {
  }

  folders: Section[] = [
    {
      photo: 'https://www.triider.com.br/img/proposta-valor-catalogo-servicos/icone-laranja-de-um-cano-com-vazamento-representando-a-categoria-hidraulica.svg',
      name: 'Hidráulicos',
    },
    {
      photo: 'https://www.triider.com.br/img/proposta-valor-catalogo-servicos/icone-laranja-de-uma-lampada-representando-a-categoria-eletrica.svg',
      name: 'Elétricos',
    },
    {
      photo: 'https://www.triider.com.br/img/proposta-valor-catalogo-servicos/icone-laranja-de-um-ar-condicionado-split-representando-a-categoria-de-ar-condicionado.svg',
      name: 'Ar-condicionado',
    },
    {
      photo: 'https://www.triider.com.br/img/proposta-valor-catalogo-servicos/icone-laranja-de-uma-chave-de-fenda-representando-a-categoria-pequenos-reparos.svg',
      name: 'Pequenos Reparos',
    },
    {
      photo: 'https://www.triider.com.br/img/proposta-valor-catalogo-servicos/icone-laranja-de-uma-furadeira-representando-a-categoria-instalacoes.svg',
      name: 'Instalações',
    },
    {
      photo: 'https://www.triider.com.br/img/proposta-valor-catalogo-servicos/icone-laranja-de-uma-persiana-representando-a-categoria-decoracao.svg',
      name: 'Decoração',
    },
    {
      photo: 'https://www.triider.com.br/img/proposta-valor-catalogo-servicos/icone-laranja-de-um-caminhao-representando-a-categoria-fretes-e-carretos.svg',
      name: 'Fretes',
    },
  ];

}
