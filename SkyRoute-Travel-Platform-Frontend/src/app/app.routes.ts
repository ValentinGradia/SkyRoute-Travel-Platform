import { Routes } from '@angular/router';
import { SearchFormComponent } from './components/search-form/search-form.component';
import { BookingFormComponent } from './components/booking-form/booking-form.component';

export const routes: Routes = [
	{
		path: '',
		redirectTo : 'search',
		pathMatch : 'full'
	},
	{
		path: 'search',
		component : SearchFormComponent
	},
	{
		path: 'bookings',
		component: BookingFormComponent
	},
];
