registerInFlapsRegistry
	"Register the receiver in the system's flaps registry."

	self environment
		at: #Flaps
		ifPresent: [:cl | (cl respondsTo: #registerQuad:forFlapNamed:)
				ifTrue: [cl registerQuad: #(#SMLoader #prototypicalToolWindow 'Package Loader' 'The SqueakMap Package Loader' ) forFlapNamed: 'Tools']]