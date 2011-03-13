serviceOpenProjectFromFile
	"Answer a service for opening a .pr project file"

	^ SimpleServiceEntry 
		provider: self 
		label: 'load as project'
		selector: #openProjectFromFile
		description: 'open project from file'
		buttonLabel: 'load'