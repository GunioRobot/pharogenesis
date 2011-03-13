methodNode
	self method isBlockMethod ifTrue: [^ self method blockNode].
	^ self method methodNode.