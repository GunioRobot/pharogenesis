parseProtoSpec: aVRMLStream
	| protoName attributes attr spec vrmlClassName |
	aVRMLStream skipSeparators.
	protoName := aVRMLStream readName.
	aVRMLStream skipSeparators.
	aVRMLStream next = $[ ifFalse:[^self error:'Interface expected'].
	attributes := OrderedCollection new.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $]] whileFalse:[
		attr := self parseAttribute: aVRMLStream from: VRMLFieldTypes.
		attr ifNotNil:[attributes add: attr].
	].
	aVRMLStream skip: 1.
	spec := VRMLNodeSpec name: protoName attributes: attributes.
	spec vrmlClass: VRMLProtoNode.
	vrmlClassName := (self vrmlClassNameFor: protoName) asSymbol.
	(Smalltalk includesKey: vrmlClassName)
		ifTrue:[spec vrmlClass: (Smalltalk at: vrmlClassName)].
	nodeTypes at: protoName put: spec.
	^spec