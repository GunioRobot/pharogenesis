registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(#Browser #prototypicalToolWindow 'Browser' 'A Browser is a tool that allows you to view all the code of all the classes in the system' ) 
						forFlapNamed: 'Tools']