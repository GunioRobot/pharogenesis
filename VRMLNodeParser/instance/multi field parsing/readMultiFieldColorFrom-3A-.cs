readMultiFieldColorFrom: aVRMLStream	"This method was automatically generated"
	| fields |
	fields := WriteStream on: (B3DColor4Array new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldColorFrom: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self readSingleFieldColorFrom: aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.