import { Component, OnInit } from '@angular/core';

export interface Section {
  photo: string;
  name: string;
  date: string;
  description: string;
}

@Component({
  selector: 'app-card-fancy',
  templateUrl: './card-fancy.component.html',
  styleUrls: ['./card-fancy.component.scss']
})
export class CardFancyComponent implements OnInit {

  selected = true;

  constructor() { }

  ngOnInit() {
  }

  folders: Section[] = [
    {
      photo: 'https://scontent.faqa1-1.fna.fbcdn.net/v/t1.6435-9/73148070_2463781607072400_6751264487061323776_n.jpg?_nc_cat=110&ccb=1-5&_nc_sid=09cbfe&_nc_eui2=AeFnwaCPowp2K40rWx-DRxfDRejjttZrA79F6OO21msDv3DKNVJde5k96s8McoKq3uHk0ZIH9tqKJx9DaOs72BEc&_nc_ohc=l8Smz1Qyub4AX8lC00o&_nc_ht=scontent.faqa1-1.fna&oh=43829421c9230cf8b964a9db64faa8ef&oe=61A7623C',
      name: 'Caio Porto',
      date: '06/10/2021',
      description: 'O aplicativo funciona perfeitamente e atende todas minhas necessidades. Os serviços foram prestados com excelência, os profissionais são educados e preparados, o atendimento ao cliente é rápido e eficiente. Fico sempre muito satisfeito e indico sem medo!'
    },
    {
      photo: 'https://avatars.githubusercontent.com/u/7596314?v=4',
      name: 'Jederson Zuchi',
      date: '16/10/2021',
      description: 'Profissionais qualificados, educados! Recebi orçamentos quase que na hora do pedido, fechei negocio muito rápido! Experiência excelente!'
    },
    {
      photo: 'https://scontent.faqa1-1.fna.fbcdn.net/v/t1.6435-9/117168993_163601225258342_8058973157684819215_n.jpg?_nc_cat=103&ccb=1-5&_nc_sid=09cbfe&_nc_eui2=AeFDKarHQ39LMS_YYIdoispXi0HoPqnjh9aLQeg-qeOH1rdvtyuuFRZ2L_s1pTljyiA1UFXS-KyTsBIUvfVVxHLz&_nc_ohc=fpSYcC7TSZcAX84F7vf&tn=kQ7r2wc3NGy2zEyj&_nc_ht=scontent.faqa1-1.fna&oh=60b67b7149eb1681b26423ebac6cc1b9&oe=61A7A266',
      name: 'João Pedro',
      date: '29/10/2021',
      description: 'Conheci e já me apaixonei, prático e eficiente'
    },
  ];
}
