serviceOpen3DSFile
	"Answer a service for opening 3-D scene file"

	^ SimpleServiceEntry 
		provider: self 
		label: 'open 3DS file'
		selector: #open3DSFile:
		description: 'open a 3-D scene file'
		buttonLabel: 'open'