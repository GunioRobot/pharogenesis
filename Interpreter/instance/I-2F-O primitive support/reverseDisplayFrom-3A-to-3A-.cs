reverseDisplayFrom: startIndex to: endIndex 
	"Reverse the given range of Display words (at different bit 
	depths, this will reverse different numbers of pixels). Used to 
	give feedback during VM activities such as garbage 
	collection when debugging. It is assumed that the given 
	word range falls entirely within the first line of the Display."
	| displayObj dispBitsPtr w reversed |
	displayObj _ self splObj: TheDisplay.
	((self isPointers: displayObj) and: [(self lengthOf: displayObj) >= 4]) ifFalse: [^ nil].
	w _ self fetchInteger: 1 ofObject: displayObj.
	dispBitsPtr _ self fetchPointer: 0 ofObject: displayObj.
	(self isIntegerObject: dispBitsPtr) ifTrue: [^ nil].
	dispBitsPtr _ dispBitsPtr + BaseHeaderSize.
	dispBitsPtr + (startIndex * 4) to: dispBitsPtr + (endIndex * 4) by: 4
		do: [:ptr | 
			reversed _ (self longAt: ptr) bitXor: 4294967295.
			self longAt: ptr put: reversed].
	self displayBitsOf: displayObj Left: 0 Top: 0 Right: w Bottom: 1.
	self ioForceDisplayUpdate