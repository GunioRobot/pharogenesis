readMultiFieldVec3fFrom: aVRMLStream	"This method was automatically generated"
	| fields |
	fields := WriteStream on: (B3DVector3Array new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldVec3fFrom: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self readSingleFieldVec3fFrom: aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.