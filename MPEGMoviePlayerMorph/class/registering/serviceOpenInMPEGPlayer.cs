serviceOpenInMPEGPlayer
	"Answer a service for opening a file in an MPEGMoviePlayer"

	^ SimpleServiceEntry 
		provider: self 
		label: 'open'
		selector: #openFile:
		description: 'open file in an MPEG player'
		buttonLabel: 'open'