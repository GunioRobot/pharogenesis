registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')
						forFlapNamed: 'Supplies'.
						cl registerQuad: #(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')
						forFlapNamed: 'Scripting']