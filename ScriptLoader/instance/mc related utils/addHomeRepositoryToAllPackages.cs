addHomeRepositoryToAllPackages
	"self new removeAllRepositories: #('http://www.squeaksource.com/Sapphire/' 			'http://www.squeaksource.com/SapphireInbox/')"
	"self new addHomeRepositoryToAllPackages"
	
	MCWorkingCopy allManagers do: [:each | 
		each repositoryGroup
			 addRepository: self repository;
			 addRepository: self inboxRepository].
	
	