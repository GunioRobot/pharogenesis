readMultiFieldStringFrom: aVRMLStream	"This method was automatically generated"
	| fields |
	fields := WriteStream on: (Array new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldStringFrom: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self readSingleFieldStringFrom: aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.