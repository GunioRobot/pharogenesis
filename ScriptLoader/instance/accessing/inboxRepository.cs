inboxRepository
	^ inboxRepository ifNil: [
		inboxRepository :=  (MCHttpRepository new 
			location: 'http://www.squeaksource.com/PharoInbox/';
			user: '';
			password: '')]
	