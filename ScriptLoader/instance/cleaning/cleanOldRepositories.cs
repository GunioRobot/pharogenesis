cleanOldRepositories
	"self new cleanOldRepositories"
	
	MCWorkingCopy allManagers do: [:each | 
		each  repositoryGroup
			removeRepository: (MCHttpRepository new location: 'http://kilana.unibe.ch:8888/Monticello');
			removeRepository: (MCHttpRepository new location: 'http://modules.squeakfoundation.org/People/gk/')].
	