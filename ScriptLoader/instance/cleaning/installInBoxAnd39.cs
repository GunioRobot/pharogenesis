installInBoxAnd39
	"self new installInBoxAnd39"
	
	MCWorkingCopy allManagers do: [:each | 
		each  repositoryGroup
			addRepository: (MCHttpRepository new location: 'http://source.squeakfoundation.org/39a' ; user: ''; password: '');
			addRepository: (MCHttpRepository new location: 'http://source.squeakfoundation.org/inbox' ; user: '' ; password: '')].
	
	