primitiveZipSendBlock
	| distTree litTree distStream litStream rcvr result |
	self export: true.
	interpreterProxy methodArgumentCount = 4 
		ifFalse:[^interpreterProxy primitiveFail].
	distTree _ interpreterProxy stackObjectValue: 0.
	litTree _ interpreterProxy stackObjectValue: 1.
	distStream _ interpreterProxy stackObjectValue: 2.
	litStream _ interpreterProxy stackObjectValue: 3.
	rcvr _ interpreterProxy stackObjectValue: 4.
	interpreterProxy failed ifTrue:[^nil].
	(self loadZipEncoderFrom: rcvr)
		ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isPointers: distTree) and:[
		(interpreterProxy slotSizeOf: distTree) >= 2])
			ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isPointers: litTree) and:[
		(interpreterProxy slotSizeOf: litTree) >= 2])
			ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isPointers: litStream) and:[
		(interpreterProxy slotSizeOf: litStream) >= 3])
			ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isPointers: distStream) and:[
		(interpreterProxy slotSizeOf: distStream) >= 3])
			ifFalse:[^interpreterProxy primitiveFail].
	self cCode:'' inSmalltalk:[
		zipMatchLengthCodes _ CArrayAccessor on: ZipWriteStream matchLengthCodes.
		zipDistanceCodes _ CArrayAccessor on: ZipWriteStream distanceCodes.
		zipExtraLengthBits _ CArrayAccessor on: ZipWriteStream extraLengthBits.
		zipExtraDistanceBits _ CArrayAccessor on: ZipWriteStream extraDistanceBits.
		zipBaseLength _ CArrayAccessor on: ZipWriteStream baseLength.
		zipBaseDistance _ CArrayAccessor on: ZipWriteStream baseDistance].
	result _ self sendBlock: litStream with: distStream with: litTree with: distTree.
	interpreterProxy failed ifFalse:[
		interpreterProxy storeInteger: 1 ofObject: rcvr withValue: zipPosition.
		interpreterProxy storeInteger: 4 ofObject: rcvr withValue: zipBitBuf.
		interpreterProxy storeInteger: 5 ofObject: rcvr withValue: zipBitPos.
	].
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 5. "rcvr + args"
		interpreterProxy pushInteger: result.
	].