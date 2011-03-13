repository
	^ repository ifNil: [
		repository := MCHttpRepository new
			location:  'http://www.squeaksource.com/Pharo';
			user: '';
			password: '']