readMultiFieldFloatFrom: aVRMLStream	"This method was automatically generated"
	| fields |
	fields := WriteStream on: (B3DFloatArray new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldFloatFrom: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self readSingleFieldFloatFrom: aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.