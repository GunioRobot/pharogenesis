parseAttribute: aVRMLStream from: aDictionary
	| attrClass type name value isEvent |
	aVRMLStream skipSeparators.
	attrClass := aVRMLStream readName.
	isEvent := attrClass = 'eventIn' or:[attrClass = 'eventOut'].
	aVRMLStream skipSeparators.
	type := aVRMLStream readName.
	aVRMLStream skipSeparators.
	name := aVRMLStream readName.
	aVRMLStream skipSeparators.
	isEvent ifFalse:[
		value := self dispatchOn: type
							in: aDictionary
							with: aVRMLStream
							ifNone:[self error:'Unknown attribute type: ',type]].
	^VRMLNodeAttribute name: name type: type value: value attrClass: attrClass