primitiveFormPrint
	"On platforms that support it, this primitive prints the receiver, assumed to be a Form, to the default printer."

	| landscapeFlag vScale hScale rcvr bitsArray w h
	 depth pixelsPerWord wordsPerLine bitsArraySize ok |
	self var: #vScale declareC: 'double vScale'.
	self var: #hScale declareC: 'double hScale'.
	landscapeFlag _ self booleanValueOf: self stackTop.
	vScale _ self floatValueOf: (self stackValue: 1).
	hScale _ self floatValueOf: (self stackValue: 2).
	rcvr _ self stackValue: 3.
	(rcvr isIntegerObject: rcvr) ifTrue: [self success: false].
	successFlag ifTrue: [
		((self  isPointers: rcvr) and: [(self lengthOf: rcvr) >= 4])
			ifFalse: [self success: false]].
	successFlag ifTrue: [
		bitsArray _ self fetchPointer: 0 ofObject: rcvr.
		w _ self fetchInteger: 1 ofObject: rcvr.
		h _ self fetchInteger: 2 ofObject: rcvr.
		depth _ self fetchInteger: 3 ofObject: rcvr.
		(w > 0 and: [h > 0]) ifFalse: [self success: false].
		pixelsPerWord _ 32 // depth.
		wordsPerLine _ (w + (pixelsPerWord - 1)) // pixelsPerWord.
		((rcvr isIntegerObject: rcvr) not and: [self isWordsOrBytes: bitsArray])
			ifTrue: [
				bitsArraySize _ self byteLengthOf: bitsArray.
				self success: (bitsArraySize = (wordsPerLine * h * 4))]
			ifFalse: [self success: false]].	
	successFlag ifTrue: [
		ok _ self cCode:
			'ioFormPrint(bitsArray + 4, w, h, depth, hScale, vScale, landscapeFlag)'.
		self success: ok].
	successFlag ifTrue: [
		self pop: 3].  "pop hScale, vScale, and landscapeFlag; leave rcvr on stack"
