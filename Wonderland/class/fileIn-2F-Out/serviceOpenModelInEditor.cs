serviceOpenModelInEditor
	"Answer a service for opening an alice model in an editor"

	^ SimpleServiceEntry 
		provider: self 
		label: 'open model in editor'
		selector: #openModelIntoAlice:
		description: 'open model in editor'
		buttonLabel: 'open'