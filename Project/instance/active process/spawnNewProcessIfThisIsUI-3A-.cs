spawnNewProcessIfThisIsUI: suspendedProcess

	world isMorph ifFalse: [^self spawnNewProcess].	"does this ever happen?"
	self activeProcess == suspendedProcess
		ifTrue: ["Transcript show: 'spawning'; cr."
				self spawnNewProcess ] 
		ifFalse: ["Transcript show: 'not spawning'; cr" ].