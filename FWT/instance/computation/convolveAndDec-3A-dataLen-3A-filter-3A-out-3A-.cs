convolveAndDec: inData dataLen: inLen filter: filter out: outData
	"convolve the input sequence with the filter and decimate by two"
	| filtLen offset outi dotp |
	filtLen _ filter size.
	outi _ 1.
	1 to: inLen+9 by: 2 do:
		[:i | 
		i < filtLen
		ifTrue:
			[dotp _ self dotpData: inData endIndex: i filter: filter
						start: 1 stop: i inc: 1]
		ifFalse:
			[i > (inLen+5)
			ifTrue:
				[offset _ i - (inLen+5).
				dotp _ self dotpData: inData endIndex: inLen+5 filter: filter
						start: 1+offset stop: filtLen inc: 1]
			ifFalse:
				[dotp _ self dotpData: inData endIndex: i filter: filter
						start: 1 stop: filtLen inc: 1]].
		outData at: outi put: dotp.
		outi _ outi + 1]