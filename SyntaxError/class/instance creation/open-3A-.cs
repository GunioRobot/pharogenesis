open: aSyntaxError 
	"Answer a standard system view whose model is an instance of me."
	<primitive: 19>
	"Simulation guard"
	self buildMorphicViewOn: aSyntaxError.
	Project spawnNewProcessIfThisIsUI: Processor activeProcess.
	^ Processor activeProcess suspend