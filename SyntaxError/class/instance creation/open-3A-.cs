open: aSyntaxError
	"Answer a standard system view whose model is an instance of me."
	| topView |
	<primitive: 19> "Simulation guard"
	Smalltalk isMorphic
		ifTrue:
			[self buildMorphicViewOn: aSyntaxError.
			Project current spawnNewProcessIfThisIsUI: Processor activeProcess.
			^ Processor activeProcess suspend].
	topView _ self buildMVCViewOn: aSyntaxError.
	topView controller openNoTerminateDisplayAt: Display extent // 2.
	Cursor normal show.
	Processor activeProcess suspend.
