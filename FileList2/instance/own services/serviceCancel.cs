serviceCancel
	"Answer a service for hitting the cancel button"

	^ (SimpleServiceEntry new
		provider: self label: 'cancel' selector: #cancelHit 
		description: 'hit here to cancel ')
		buttonLabel: 'cancel'