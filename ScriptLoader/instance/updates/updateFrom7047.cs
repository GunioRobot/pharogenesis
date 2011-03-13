updateFrom7047

	"self new updateFrom7047"
	self script78.
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.
	ServiceRegistry initialize.
	
	self unloadPackages.
	AppRegistry removeObsolete.
	FileServices removeObsolete. 
	Undeclared removeUnreferencedKeys.
	self flushCaches.
	MCDefinition clearInstances.
	Preferences addPreference: #multipleTextUndo
		categories: #('general') default: false 
		balloonHelp: 'Editors track a multiple undo history'.
	