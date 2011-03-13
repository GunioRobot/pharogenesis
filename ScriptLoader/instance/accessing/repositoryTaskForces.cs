repositoryTaskForces
	^ repositoryTaskForces ifNil: [
		repositoryTaskForces := MCHttpRepository new
			location:  'http://www.squeaksource.com/PharoTaskForces';
			user: '';
			password: '']