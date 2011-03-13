refreshAndSignal: aBoolean
	| node oldChildren shouldSignal |
	shouldSignal _ aBoolean.
	self isEmpty ifTrue: [^self].
	node := self selectedNode.
	oldChildren := children.
	self getChildren.
	children = oldChildren ifFalse: 
		[self selectSilently: node.
		self hasSelection ifFalse: 
			[shouldSignal _ true]].
	shouldSignal ifTrue: [self signalSelectionChanged].
	self changed: #list