registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(FrameRateMorph		authoringPrototype		'Frame Rate'		'An indicator of how fast your system is running')
						forFlapNamed: 'Widgets']