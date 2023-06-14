import { Component, OnInit } from '@angular/core';

export interface Section {
  photo: string;
  name: string;
  description: string;
  link: string;
}

/**
 * @title List with sections
 */

@Component({
  selector: 'app-how-to-work',
  templateUrl: './how-to-work.component.html',
  styleUrls: ['./how-to-work.component.scss']
})
export class HowToWorkComponent implements OnInit {
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  folders: Section[] = [
    {
      photo: 'https://www.triider.com.br/_next/image?url=%2Fimg%2Ftemplate%2Fhow2.png&w=256&q=75',
      name: '1. PREENCHER O PERFIL',
      description: 'Explique o serviço que você precisa em um formulário!',
      link: 'Veja como Funciona.'
    },
    {
      photo: 'https://www.triider.com.br/_next/image?url=%2Fimg%2Ftemplate%2Fhow2.png&w=256&q=75',
      name: '2. ESCOLHA UM PROFISSIONAL',
      description: 'Receba orçamentos, converse e escolha um profissional adequado!',
      link: 'Nossos profissionais.'
    },
    {
      photo: 'https://www.triider.com.br/_next/image?url=%2Fimg%2Ftemplate%2Fhow3.png&w=256&q=75',
      name: '3. SERVIÇO REALIZADO',
      description: 'O profissional vai na sua casa na data acordada e faz o serviço!',
      link: 'Tire suas Dúvidas.'
    },
    {
      photo: 'https://www.triider.com.br/_next/image?url=%2Fimg%2Ftemplate%2Fhow4.png&w=256&q=75',
      name: '4. PAGUE DEPOIS',
      description: 'Pague na plataforma com o seu cartão em até 6x só depois do serviço realizado!',
      link: 'Formas de Pagamento.'
    },
  ];
}
