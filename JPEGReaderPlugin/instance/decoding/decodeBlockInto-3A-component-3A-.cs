decodeBlockInto: anArray component: aColorComponent
	| byte zeroCount bits index |
	self var: #anArray type: 'int *'.
	self var: #aColorComponent type: 'int *'.
	byte _ self jpegDecodeValueFrom: dcTable size: dcTableSize.
	byte < 0 ifTrue:[^interpreterProxy primitiveFail].
	byte ~= 0 ifTrue: [
		bits _ self getBits: byte.
		byte _ self scaleAndSignExtend: bits inFieldWidth: byte].
	byte _ aColorComponent 
				at: PriorDCValueIndex 
				put: (aColorComponent at: PriorDCValueIndex) + byte.
	anArray at: 0 put: byte.
	1 to: DCTSize2 - 1 do:[:i| anArray at: i put: 0].
	index _ 1.
	[index < DCTSize2] whileTrue:[
		byte _ self jpegDecodeValueFrom: acTable size: acTableSize.
		byte < 0 ifTrue:[^interpreterProxy primitiveFail].
		zeroCount _ byte >> 4.
		byte _ byte bitAnd: 16r0F.
		byte ~= 0 ifTrue:[
			index _ index + zeroCount.
			bits _  self getBits: byte.
			byte _ self scaleAndSignExtend: bits inFieldWidth: byte.
			(index < 0 or:[index >= DCTSize2]) ifTrue:[^interpreterProxy primitiveFail].
			anArray at:	 (jpegNaturalOrder at: index) put: byte.
		] ifFalse:[
			zeroCount = 15 ifTrue: [index _ index + zeroCount] ifFalse: [^ nil].
		].
		index _ index + 1
	].