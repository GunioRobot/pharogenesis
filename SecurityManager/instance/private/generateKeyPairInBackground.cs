generateKeyPairInBackground
	"SecurityManager default generateKeyPairInBackground"
	"Silently generate a key set on the local machine while running in the background."
	| guesstimate startTime |
	guesstimate _ [10 benchmark] timeToRun * 150.
	startTime _ Time millisecondClockValue.
	privateKeyPair _ nil.
	[self generateLocalKeyPair] fork.
	Utilities informUserDuring:[:bar|
		[privateKeyPair == nil] whileTrue:[
			bar value:'Initializing Squeak security system (', (Time millisecondClockValue - startTime * 100 // guesstimate) printString,'%)'.
			(Delay forSeconds: 1) wait.
		].
	].
