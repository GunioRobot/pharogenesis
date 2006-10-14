cleanOldRepositories
	"self new cleanOldRepositories"
	"does not work since the interface of the repository group is not made for removing a repository only based on name"
	
	MCWorkingCopy allManagers do: [:each | 
		each  repositoryGroup
			removeRepository: (MCHttpRepository new location: 'http://kilana.unibe.ch:8888/Monticello');
			removeRepository: (MCHttpRepository new location: 'http://modules.squeakfoundation.org/People/gk/')].
	