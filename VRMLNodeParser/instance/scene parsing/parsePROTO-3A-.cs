parsePROTO: aVRMLStream
	| spec nodeList node protoNode protoAttr |
	spec := self parseProtoSpec: aVRMLStream.
	aVRMLStream skipSeparators.
	aVRMLStream next = ${ ifFalse:[^self error:'Prototype body expected'].
	protoList ifNil:[protoList := OrderedCollection new].
	protoList add: spec.
	nodeList := OrderedCollection new.
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $}] whileFalse:[
		node := self parseStatement: aVRMLStream.
		node ifNotNil:[nodeList add: node].
	].
	aVRMLStream skip: 1.
	protoList remove: spec.
	protoNode := VRMLProtoClassNode fromSpec: spec.
	protoNode protoValues: nodeList.
	protoAttr := VRMLDynamicAttribute name:'protoType' type: 'SFNode' value: protoNode attrClass: nil.
	spec addAttribute: protoAttr.
	scene addPrototype: protoNode spec: spec.
	scene addNode: protoNode.
	protoList isEmpty ifTrue:[protoList := nil].
	^nil