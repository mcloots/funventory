import { Route } from '@angular/router';

export const appRoutes: Route[] = [
    {
        path: 'management/programmes',
        loadComponent: () =>
            import('@mcloots/eduhub-frontend').then((m) => m.ProgrammeManageComponent)
    }
];
