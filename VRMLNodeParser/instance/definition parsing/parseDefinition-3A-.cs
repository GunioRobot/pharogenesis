parseDefinition: aVRMLStream
	| name attributes attr spec vrmlClassName |
	aVRMLStream skipSeparators.
	name := aVRMLStream readName.
	aVRMLStream skipSeparators.
	aVRMLStream nextChar = ${ ifFalse:[
		self error:'Node definition expected'.
	].
	attributes := OrderedCollection new.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $}] whileFalse:[
		attr := self parseAttribute: aVRMLStream from: VRMLScriptFieldTypes.
		attr ifNotNil:[attributes add: attr].
	].
	aVRMLStream skip: 1.
	spec := VRMLNodeSpec name: name attributes: attributes.
	vrmlClassName := (self vrmlClassNameFor: name) asSymbol.
	(Smalltalk includesKey: vrmlClassName)
		ifTrue:[spec vrmlClass: (Smalltalk at: vrmlClassName)]
		ifFalse:[spec vrmlClass: VRMLStandardNode].
	^spec