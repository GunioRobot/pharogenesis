registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(MPEGMoviePlayerMorph	authoringPrototype		'Movie Player'		'A Player for MPEG movies') 
						forFlapNamed: 'Widgets']
