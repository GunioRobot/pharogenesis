serviceLoadAFilForDummyTool
	"Answer a service for opening the Dummy tool"

	^ SimpleServiceEntry 
		provider: self 
		label: 'menu label'
		selector: #loadAFileForTheDummyTool:
		description: 'Menu label for dummy tool'
		buttonLabel: 'test'