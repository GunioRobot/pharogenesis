removeAllRepositories: aColl
	"self new removeAllRepositories: 
			#('http://source.squeakfoundation.org/inbox/'
			 'http://source.squeakfoundation.org/39a/'
			 'http://source.squeakfoundation.org/Balloon/'
			 'http://source.squeakfoundation.org/Compression/'
			 'http://source.squeakfoundation.org/Graphics/'
			  'http://source.wiresong.ca/mc/')"

	
	MCWorkingCopy allManagers do: [:each | 
		aColl
			do: [:location | 
					each  repositoryGroup removeHTTPRepositoryLocationNamed: location]].
	