registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(ClockMorph	authoringPrototype		'Clock'			'A simple digital clock')
						forFlapNamed: 'Supplies'.
						cl registerQuad: #(ClockMorph	authoringPrototype		'Clock'			'A simple digital clock')
						forFlapNamed: 'PlugIn Supplies'.]