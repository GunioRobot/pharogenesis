selectInvisiblyFrom: start to: stop
	"Select the designated characters, inclusive.  Make no visual changes."

	(start = startBlock stringIndex and: [stop + 1 = stopBlock stringIndex]) ifFalse:
		[self computeIntervalFrom: start to: stop]