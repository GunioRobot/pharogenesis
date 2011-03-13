registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(MessageNames			prototypicalToolWindow		'Message Names'		'A tool for finding, viewing, and editing all methods whose names contain a given character sequence.')
						forFlapNamed: 'Tools']