registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(MagnifierMorph		newRound	'Magnifier'			'A magnifying glass') 
						forFlapNamed: 'Widgets']