registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(Celeste		newOpenableMorph		'Celeste'		'Celeste -- an EMail reader') 
						forFlapNamed: 'Tools']