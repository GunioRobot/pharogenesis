registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(RectangleMorph	roundRectPrototype		'RoundRect'		'A rectangle with rounded corners')
						forFlapNamed: 'Supplies'.
						cl registerQuad: #(RectangleMorph	authoringPrototype		'Rectangle' 		'A rectangle')
						forFlapNamed: 'Supplies'.
						cl registerQuad: #(RectangleMorph	roundRectPrototype		'RoundRect'		'A rectangle with rounded corners')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(RectangleMorph	authoringPrototype		'Rectangle' 		'A rectangle')
						forFlapNamed: 'PlugIn Supplies'.]