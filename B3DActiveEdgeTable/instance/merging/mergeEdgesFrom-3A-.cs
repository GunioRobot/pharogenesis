mergeEdgesFrom: inputList
	"Merge all the edges from the given input list in the AET"
	| srcIndex dstIndex outIndex srcEdge dstEdge |
	srcIndex _ inputList size.
	srcIndex = 0 ifTrue:[^self].
	dstIndex _ stop.
	"Make room for adding the stuff"
	[stop + srcIndex > array size] whileTrue:[self grow].
	"Adjust size"
	stop _ stop + srcIndex.
	"If the receiver is empty, simply copy the stuff"
	dstIndex = 0 ifTrue:[
		1 to: srcIndex do:[:i| array at: i put: (inputList at: i)].
		^self].
	"Merge inputList by walking backwards through the AET and checking each edge."
	outIndex _ dstIndex+srcIndex.
	srcEdge _ inputList at: srcIndex.
	dstEdge _ array at: dstIndex.
	[true] whileTrue:[
		srcEdge xValue >= dstEdge xValue ifTrue:[
			"Insert srcEdge"
			array at: outIndex put: srcEdge.
			srcIndex _ srcIndex - 1.
			srcIndex = 0 ifTrue:[^self].
			srcEdge _ inputList at: srcIndex.
		] ifFalse:[
			"Insert dstEdge"
			array at: outIndex put: dstEdge.
			dstIndex _ dstIndex - 1.
			dstIndex = 0 ifTrue:[
				1 to: srcIndex do:[:i| array at: i put: (inputList at: i)].
				^self].
			dstEdge _ array at: dstIndex.
		].
		outIndex _ outIndex-1.
	].