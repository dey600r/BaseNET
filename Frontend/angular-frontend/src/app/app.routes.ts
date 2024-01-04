import { Routes } from '@angular/router';
import { UrlConstants } from '@utils/index';
import { AuthGuard } from '@app/core/guards/user.guard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: UrlConstants.URL_HOME,
        pathMatch: 'full'
    },
    {
        path: '',
        loadChildren: () => import('./pages/pages.module').then(mod => mod.PagesModule),
        canActivate: [AuthGuard]
    },
    {
        path: UrlConstants.URL_LOGIN,
        loadChildren: () => import('./pages/security/login/login.module').then(mod => mod.LoginModule)
    },
    {
        path: '**',
        redirectTo: UrlConstants.URL_LOGIN
      }
];
