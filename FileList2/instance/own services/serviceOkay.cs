serviceOkay
	"Answer a service for hitting the okay button"

	^ (SimpleServiceEntry new
		provider: self label: 'okay' selector: #okHit 
		description: 'hit here to accept the current selection')
		buttonLabel: 'ok'