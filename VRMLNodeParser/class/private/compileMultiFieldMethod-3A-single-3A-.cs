compileMultiFieldMethod: selString single: singleString
	| source |
	source := String streamContents:[:s|
		s nextPutAll: selString.
		s nextPutAll:' aVRMLStream'.
		s nextPutAll:(
'	"This method was automatically generated"
	| fields |
	fields := OrderedCollection new.
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	(aVRMLStream nextChar = $[) ifFalse:[
		aVRMLStream restore.
		fields add: (self $READSINGLE$ aVRMLStream).
		^fields].
	aVRMLStream discard.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $] ] whileFalse:[
		fields add: (self $READSINGLE$ aVRMLStream).
	].
	aVRMLStream nextChar.
	^fields.' copyReplaceAll:'$READSINGLE$' with: singleString).
	].
	self compile: source classified:'multi field parsing'