parseDEF: aVRMLStream
	| nodeName nodeValue |
	aVRMLStream skipSeparators.
	defName := nodeName := aVRMLStream readName.
	nodeValue := self parseStatement: aVRMLStream.
	defName := nil.
	^VRMLDefNode name: nodeName node: nodeValue