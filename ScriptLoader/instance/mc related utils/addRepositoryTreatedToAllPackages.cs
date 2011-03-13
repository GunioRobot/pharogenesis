addRepositoryTreatedToAllPackages
	"self new addRepositoryTreatedToAllPackages"
	
	MCWorkingCopy allManagers do: [:each | 
		each repositoryGroup
			 addRepository: self repositoryTreated
			].
	
	