registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(TranscriptStream		openMorphicTranscript	'Transcript'			'A Transcript is a window usable for logging and debugging; browse references to #Transcript for examples of how to write to it.')
						forFlapNamed: 'Tools']
