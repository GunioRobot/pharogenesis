computeIntervalFrom: start to: stop
	"Select the designated characters, inclusive.  Make no visual changes."

	startBlock _ paragraph characterBlockForIndex: start.
	stopBlock _ start > stop
		ifTrue: [startBlock copy]
		ifFalse: [paragraph characterBlockForIndex: stop + 1]