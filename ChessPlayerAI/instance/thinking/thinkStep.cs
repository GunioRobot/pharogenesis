thinkStep
	transTable ifNil: [self initializeTranspositionTable].
	myProcess isNil 
		ifTrue: 
			[myMove := #none.
			false 
				ifTrue: 
					[self thinkProcess.
					^myMove].
			myProcess := [self thinkProcess] forkAt: Processor userBackgroundPriority.
			myProcess suspend.
			^nil].
	myProcess resume.
	(Delay forMilliseconds: 50) wait.
	myProcess ifNil: [^myMove == #none ifTrue: [nil] ifFalse: [myMove]].
	myProcess suspend.
	"Do we have a valid move?"
	myMove == #none ifTrue: [^nil].	"no"
	"Did we time out?"
	Time millisecondClockValue - startTime > self timeToThink 
		ifTrue: 
			["Yes. Abort and return current move."

			stopThinking := true.
			myProcess resume.
			[myProcess isNil] whileFalse: [(Delay forMilliseconds: 10) wait].
			^myMove == #none ifTrue: [nil] ifFalse: [myMove]].
	"Keep thinking"
	^nil