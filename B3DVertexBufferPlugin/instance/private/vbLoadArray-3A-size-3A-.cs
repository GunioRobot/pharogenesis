vbLoadArray: oop size: count
	"Load the word based array of size count from the given oop"
	self returnTypeC: 'void*'.
	self inline: false.
	oop == nil ifTrue:[interpreterProxy primitiveFail. ^nil].
	oop == interpreterProxy nilObject ifTrue:[^nil].
	(interpreterProxy isWords: oop) 
		ifFalse:[interpreterProxy primitiveFail. ^nil].
	(interpreterProxy slotSizeOf: oop) = count
		ifFalse:[interpreterProxy primitiveFail. ^nil].
	^interpreterProxy firstIndexableField: oop