import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BancosDadosComponent } from './components/bancosDados/bancosDados/bancosDados.component';
import { ChamadosComponent } from './components/chamados/chamados.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { DNSsComponent } from './components/dns/dns/dns.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ChamadoDetalheComponent } from './components/chamados/chamado-detalhe/chamado-detalhe.component';
import { ChamadoFormComponent } from './components/chamados/chamado-form/chamado-form.component';
import { ChamadoListaComponent } from './components/chamados/chamado-lista/chamado-lista.component';
import { ChamadoEditarComponent } from './components/chamados/chamado-editar/chamado-editar.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
// import { RegisterComponent } from './components/user/register/register.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { ClienteDetalheComponent } from './components/clientes/cliente-detalhe/cliente-detalhe.component';
import { ClienteFormComponent } from './components/clientes/cliente-form/cliente-form.component';
import { ClienteEditarComponent } from './components/clientes/cliente-editar/cliente-editar.component';
import { ClienteListaComponent } from './components/clientes/cliente-lista/cliente-lista.component';
import { DnsDetalheComponent } from './components/dns/dns-detalhe/dns-detalhe.component';
import { DnsFormComponent } from './components/dns/dns-form/dns-form.component';
import { DnsListaComponent } from './components/dns/dns-lista/dns-lista.component';
import { DnsEditarComponent } from './components/dns/dns-editar/dns-editar.component';
import { BancoDadosDetalheComponent } from './components/bancosDados/banco-dados-detalhe/banco-dados-detalhe.component';
import { BancoDadosFormComponent } from './components/bancosDados/banco-dados-form/banco-dados-form.component';
import { BancoDadosListaComponent } from './components/bancosDados/banco-dados-lista/banco-dados-lista.component';
import { BancoDadosEditarComponent } from './components/bancosDados/banco-dados-editar/banco-dados-editar.component';
import { AuthGuard } from './guard/auth.guard';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [

  {path: '', redirectTo: 'user/login', pathMatch: 'full'},

  {
    path: "user", component: UserComponent,
    children:[
      {path: "login", component: LoginComponent},
      {path: "registration", component: RegistrationComponent},

    ]
  },

  {
    path:'',
    runGuardsAndResolvers: 'always',
    canActivate:[AuthGuard],
    children: [
      {path: "dashboard", component: DashboardComponent},
      // {path: '**', redirectTo: 'dashboard', pathMatch: 'full'},

      {path: "user", redirectTo: "user/perfil"},
      {path: "user/perfil", component: PerfilComponent},

      {path: "bancoDados", redirectTo: 'bancoDados/lista'},
      {path: "bancoDados", component: BancosDadosComponent,
      children:[

        {path: 'detalhe/:id', component: BancoDadosDetalheComponent},
        {path: 'form', component: BancoDadosFormComponent},
        {path: 'lista', component: BancoDadosListaComponent},
        {path: 'editar/:id', component: BancoDadosEditarComponent},
       ]
      },


      {path: "chamados", redirectTo: 'chamados/lista'},
      {path: "chamados", component: ChamadosComponent,
       children:[
        {path: 'detalhe/:id', component: ChamadoDetalheComponent},
        {path: 'form', component: ChamadoFormComponent},
        {path: 'lista', component: ChamadoListaComponent},
        {path: 'editar/:id', component: ChamadoEditarComponent},
       ]
      },

      {path: "clientes", redirectTo: 'clientes/lista'},
      {path: "clientes", component: ClientesComponent,
        children:[
        {path: 'detalhe/:id', component: ClienteDetalheComponent},
        {path: 'form', component: ClienteFormComponent},
        {path: 'lista', component: ClienteListaComponent},
        {path: 'editar/:id', component: ClienteEditarComponent},
        ]
      },


      {path: "dns", redirectTo: 'dns/lista'},
      {path: "dns", component: DNSsComponent,
        children:[
        {path: 'detalhe/:id', component: DnsDetalheComponent},
        {path: 'form', component: DnsFormComponent},
        {path: 'lista', component: DnsListaComponent},
        {path: 'editar/:id', component: DnsEditarComponent},
        ]
      },
    ]
  },

  {path: "user", component: HomeComponent},
  { path: '**', redirectTo: 'user/login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
