buildWindowMenu
	"Answer the menu to be put up in response to the user's clicking on the window-menu control in the window title.  Specialized for CollapsedMorphs."

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu add: 'change name...' action: #relabel.
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
	^aMenu