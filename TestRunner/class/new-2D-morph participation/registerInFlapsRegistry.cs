registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | (cl respondsTo: #registerQuad:forFlapNamed:)
				ifTrue: [cl registerQuad: #(#TestRunner #prototypicalToolWindow 'Test Runner' 'The SUnit Test Runner' ) forFlapNamed: 'Tools']]