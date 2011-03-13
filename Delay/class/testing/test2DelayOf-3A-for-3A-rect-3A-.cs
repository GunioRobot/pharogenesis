test2DelayOf: delay for: testCount rect: r
	"Transcript cr. 
	 Delay test2DelayOf: 100 for: 20 rect: (10@10 extent: 10@10).
	 Delay test2DelayOf: 400 for: 20 rect: (25@10 extent: 10@10)."

	| myDelay pauseDelay |
	myDelay    _ Delay forMilliseconds: delay - 50.
	pauseDelay _ Delay forMilliseconds: 50.
	Display fillBlack: r.
	[	1 to: testCount do: [ :i |
			Display fillWhite: r.
			pauseDelay wait.
			Display reverse: r.
			myDelay wait.
		].
	] forkAt: Processor userInterruptPriority.
