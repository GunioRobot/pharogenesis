named: projName
	"Answer the project with the given name, or the current project if there is no project of that given name."
	"(Project named: 'zork') enter"

	^ self allInstances
		detect: [:proj | proj name = projName]
		ifNone: [self current]
