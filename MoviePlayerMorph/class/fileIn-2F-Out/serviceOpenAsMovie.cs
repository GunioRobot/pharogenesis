serviceOpenAsMovie
	"Answer a service for opening a file as a movie"

	^ SimpleServiceEntry 
		provider: self 
		label: 'open as movie'
		selector: #openAsMovie:
		description: 'open file as movie'
		buttonLabel: 'open'