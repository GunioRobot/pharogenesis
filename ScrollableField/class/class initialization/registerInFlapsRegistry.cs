registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(ScrollableField			newStandAlone		'Scrolling Text'		'Holds any amount of text; has a scroll bar')
						forFlapNamed: 'Stack Tools'.]