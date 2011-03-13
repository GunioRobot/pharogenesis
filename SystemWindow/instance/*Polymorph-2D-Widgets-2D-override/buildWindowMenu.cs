buildWindowMenu
	"Build and answer the window menu."
	
	| aMenu |
	aMenu := self theme newMenuIn: self for: self.
	aMenu addToggle: 'close' translated target: self
		selector: #closeBoxHit getStateSelector: nil
		enablementSelector: #allowedToClose.
	aMenu lastItem icon: self theme windowCloseForm.
	aMenu addLine.
	aMenu add: 'about' translated action: #showAbout.
	aMenu lastItem icon: MenuIcons smallHelpIcon.
	aMenu addLine.
	aMenu addLine.
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
	self isMaximized
		ifTrue: [aMenu add: 'restore' translated action: #expandBoxHit.
				aMenu lastItem icon: self theme windowMaximizeForm]
		ifFalse: [aMenu add: 'maximize' translated action: #expandBoxHit.
				aMenu lastItem icon: self theme windowMaximizeForm].
	self isCollapsed ifFalse: [aMenu add: 'window color...' translated action: #setWindowColor].
	^aMenu