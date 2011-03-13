registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(CurveMorph		authoringPrototype		'Curve'		'A curve')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(CurveMorph		authoringPrototype		'Curve'		'A curve')
						forFlapNamed: 'Supplies'.]