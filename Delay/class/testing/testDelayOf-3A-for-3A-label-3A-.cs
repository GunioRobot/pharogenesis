testDelayOf: delay for: testCount label: label
	"Transcript cr. 
	 Delay testDelayOf: 1000 for: 10 label: 'A'. 
	 Delay testDelayOf: 2000 for: 10 label: 'B'"

	| myDelay |
	myDelay _ Delay forMilliseconds: delay.
	[	1 to: testCount do: [ :i |
			myDelay wait.
			Transcript show: label, i printString; cr.
		].
	] forkAt: Processor userInterruptPriority.
