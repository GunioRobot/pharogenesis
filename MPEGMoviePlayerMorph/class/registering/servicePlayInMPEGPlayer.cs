servicePlayInMPEGPlayer
	"Answer a service for opening in a MPEG player"

	^ SimpleServiceEntry
		provider: self
		label: 'play in MPEG player'
		selector: #playFile: 
		description: 'play in MPEG player'
		buttonLabel: 'play'