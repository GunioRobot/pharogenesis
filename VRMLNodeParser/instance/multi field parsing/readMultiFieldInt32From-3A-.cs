readMultiFieldInt32From: aVRMLStream	"This method was automatically generated"
	| fields |
	fields := WriteStream on: (IntegerArray new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldInt32From: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self readSingleFieldInt32From: aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.