buildWindowMenu
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu add: 'change title...' translated action: #relabel.
	aMenu addLine.
	aMenu add: 'send to back' translated action: #sendToBack.
	aMenu add: 'make next-to-topmost' translated action: #makeSecondTopmost.
	aMenu addLine.
	self mustNotClose
		ifFalse:
			[aMenu add: 'make unclosable' translated action: #makeUnclosable]
		ifTrue:
			[aMenu add: 'make closable' translated action: #makeClosable].
	aMenu
		add: (self isSticky ifTrue: ['make draggable'] ifFalse: ['make undraggable']) translated 
		action: #toggleStickiness.
	aMenu addLine.
	aMenu add: 'full screen' translated action: #fullScreen.
	self isCollapsed ifFalse: [aMenu add: 'window color...' translated action: #setWindowColor].
	^aMenu