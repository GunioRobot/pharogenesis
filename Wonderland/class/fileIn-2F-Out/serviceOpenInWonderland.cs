serviceOpenInWonderland
	"Answer a service for opening a file in Wonderland"

	^ SimpleServiceEntry 
			provider: self 
			label: 'open in Wonderland'
			selector: #openVRMLFile:
			description: 'open in Wonderland' 
			buttonLabel: 'open'