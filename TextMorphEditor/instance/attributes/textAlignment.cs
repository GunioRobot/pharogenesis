textAlignment
	"Answer 1..4, representing #leftFlush, #rightFlush, #centered, or #justified"
	^paragraph text alignmentAt: startBlock stringIndex
		ifAbsent: [paragraph textStyle alignment]