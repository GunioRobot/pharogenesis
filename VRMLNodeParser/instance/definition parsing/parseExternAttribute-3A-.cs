parseExternAttribute: aVRMLStream
	| attrClass type name isEvent |
	aVRMLStream skipSeparators.
	attrClass := aVRMLStream readName.
	isEvent := attrClass = 'eventIn' or:[attrClass = 'eventOut'].
	aVRMLStream skipSeparators.
	type := aVRMLStream readName.
	aVRMLStream skipSeparators.
	name := aVRMLStream readName.
	aVRMLStream skipSeparators.
	isEvent ifTrue:[^nil].
	^VRMLNodeAttribute name: name type: type value: nil attrClass: attrClass