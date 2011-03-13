installRemoteNamed: remoteFileName from: aServer named: otherProjectName in: currentProject

	"Find the current ProjectViewMorph, fetch the project, install in ProjectViewMorph without changing size, and jump into new project."

	ProgressNotification signal: '1:foundMostRecent'.
	^self 
		openFromFile: (aServer oldFileNamed: remoteFileName) 
		fromDirectory: aServer 
		withProjectView: (currentProject findProjectView: otherProjectName).
