serviceOpenInZipViewer
	"Answer a service for opening in a zip viewer"

	^ SimpleServiceEntry
		provider: self
		label: 'open in zip viewer'
		selector: #openOn: 
		description: 'open in zip viewer'
		buttonLabel: 'open zip'