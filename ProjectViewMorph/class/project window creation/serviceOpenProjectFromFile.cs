serviceOpenProjectFromFile
	"Answer a service for opening a .pr project file"

	^ (SimpleServiceEntry 
		provider: self 
		label: 'load as project'
		selector: #openFromDirectoryAndFileName:
		description: 'open project from file'
		buttonLabel: 'load'
	)
		argumentGetter: [ :fileList | fileList dirAndFileName]