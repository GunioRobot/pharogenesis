buildWindowMenu
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu add: 'change title...' action: #relabel.
	aMenu addLine.
	aMenu add: 'send to back' action: #sendToBack.
	aMenu add: 'make next-to-topmost' action: #makeSecondTopmost.
	aMenu addLine.
	self mustNotClose
		ifFalse:
			[aMenu add: 'make unclosable' action: #makeUnclosable]
		ifTrue:
			[aMenu add: 'make closable' action: #makeClosable].
	aMenu add: (self isSticky ifTrue: ['make draggable'] ifFalse: ['make undraggable']) 
		action: #toggleStickiness.
	aMenu addLine.
	aMenu add: 'full screen' action: #fullScreen.
	self isCollapsed ifFalse: [aMenu add: 'window color...' action: #setWindowColor].
	^aMenu