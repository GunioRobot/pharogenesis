compileMultiFieldMethod: selString single: singleString type: mfFieldType
	| source |
	source := String streamContents:[:s|
		s nextPutAll: selString.
		s nextPutAll:' aVRMLStream'.
		s nextPutAll:((
'	"This method was automatically generated"
	| fields |
	fields := WriteStream on: ($MF_FIELD_TYPE$ new: 100).
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields nextPut: (self $READSINGLE$ aVRMLStream).
		^fields contents].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields nextPut: (self $READSINGLE$ aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields contents.' 
		copyReplaceAll:'$READSINGLE$' with: singleString)
		copyReplaceAll:'$MF_FIELD_TYPE$' with: mfFieldType).
	].
	self compile: source classified:'multi field parsing'