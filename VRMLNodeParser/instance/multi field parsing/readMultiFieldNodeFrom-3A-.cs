readMultiFieldNodeFrom: aVRMLStream	"This method was automatically generated"
	| fields |
	fields := WriteStream on: (Array new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldNodeFrom: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self readSingleFieldNodeFrom: aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.