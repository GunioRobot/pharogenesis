registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(PolygonMorph	authoringPrototype		'Polygon'	'A straight-sided figure with any number of sides')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(PolygonMorph	authoringPrototype		'Polygon'	'A straight-sided figure with any number of sides')
						forFlapNamed: 'Supplies'.]