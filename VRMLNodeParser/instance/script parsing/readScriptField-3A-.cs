readScriptField: aVRMLStream
	| type name outer |
	aVRMLStream skipSeparators.
	type := aVRMLStream readName.
	aVRMLStream skipSeparators.
	name := aVRMLStream readName.
	aVRMLStream skipSeparators.
	aVRMLStream backup.
	aVRMLStream readName = 'IS' ifTrue:[
		aVRMLStream discard.
		aVRMLStream skipSeparators.
		outer := aVRMLStream readName.
	] ifFalse:[aVRMLStream restore].
	^nil