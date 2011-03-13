registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | 	cl registerQuad: #(ProcessBrowser			prototypicalToolWindow		'Processes'			'A Process Browser shows you all the running processes')
						forFlapNamed: 'Tools'.]