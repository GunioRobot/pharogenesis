readMultiFieldVec2fFrom: aVRMLStream	"This method was automatically generated"
	| fields nFields |
	fields := WriteStream on: (B3DVector2Array new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self readSingleFieldVec2fFrom: aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	nFields _ 0.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		(nFields bitAnd: 255) = 0 ifTrue:[self progressUpdate: aVRMLStream].
		fields nextPut: (self readSingleFieldVec2fFrom: aVRMLStream).
		nFields _ nFields + 1.
	].
	aVRMLStream nextChar.
	^fields contents.