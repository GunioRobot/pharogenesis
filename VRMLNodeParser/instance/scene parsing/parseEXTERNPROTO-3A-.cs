parseEXTERNPROTO: aVRMLStream
	| spec urlList subScene protoNode |
	spec := self parseExternProtoSpec: aVRMLStream.
	aVRMLStream skipSeparators.
	urlList := self readMultiFieldStringFrom: aVRMLStream.
	subScene := self class parseURLs: urlList.
	scene addPrototype: (subScene prototypeAt: spec name) spec: spec.
	protoNode := (VRMLExternProtoClassNode fromSpec: spec) urlList: urlList.
	scene addNode: protoNode.
	^nil