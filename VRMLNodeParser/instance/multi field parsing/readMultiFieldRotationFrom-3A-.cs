readMultiFieldRotationFrom: aVRMLStream	"This method was automatically generated"
	| fields |
	fields := WriteStream on: (B3DRotationArray new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldRotationFrom: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self readSingleFieldRotationFrom: aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.