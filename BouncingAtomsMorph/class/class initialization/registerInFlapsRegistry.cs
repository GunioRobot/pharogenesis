registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(BouncingAtomsMorph	new	'Bouncing Atoms'	'Atoms, mate')
						forFlapNamed: 'Widgets']