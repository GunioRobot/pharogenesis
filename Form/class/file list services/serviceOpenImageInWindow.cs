serviceOpenImageInWindow
	"Answer a service for opening a graphic in a window"

	^ SimpleServiceEntry 
		provider: self 
		label: 'open graphic in a window'
		selector: #openImageInWindow:
		description: 'open a graphic file in a window'
		buttonLabel: 'open'