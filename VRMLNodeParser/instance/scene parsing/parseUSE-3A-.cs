parseUSE: aVRMLStream
	| nodeName |
	aVRMLStream skipSeparators.
	nodeName := aVRMLStream readName.
	^VRMLUseNode name: nodeName node: (scene definedNode: nodeName)