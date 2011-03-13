addCustomMenuItems: menu hand: aHandMorph

	| subMenu |
	super addCustomMenuItems: menu hand: aHandMorph.

	self isStackLike
		ifTrue:
			[subMenu _ MenuMorph new defaultTarget: self.
			subMenu add: 'new card' action: #newCard.
			subMenu add: 'delete this card' action: #deleteCard.
			subMenu add: 'go to next card' action: #goToNextCard.
			subMenu add: 'go to previous card' action: #goToPreviousCard.
			menu add: 'card & stack...' subMenu: subMenu]
		ifFalse:
			[menu add: 'become a stack' action: #becomeStack].
	
	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'clear pen trails' action: #clearTurtleTrails.
	subMenu add: 'all pens up' action: #liftAllPens.
	subMenu add: 'all pens down' action: #lowerAllPens.
	menu add: 'pens trails within...' subMenu: subMenu.

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'save on file...' action: #saveOnFile.
	subMenu add: 'navigate to...' action: #navigateTo.

	self autoLineLayout
		ifTrue:
			[subMenu add: 'stop auto layout' action: #toggleAutoLineLayout]
		ifFalse:
			[subMenu add: 'start auto layout' action: #toggleAutoLineLayout].
	self resizeToFit
		ifTrue:
			[subMenu add: 'stop resize-to-fit' action: #toggleResizeToFit]
		ifFalse:
			[subMenu add: 'start resize-to-fit' action: #toggleResizeToFit].
	self indicateCursor
		ifTrue:
			[subMenu add: 'stop showing cursor' action: #toggleIndicateCursor]
		ifFalse:
			[subMenu add: 'start showing cursor' action: #toggleIndicateCursor].
	self isPartsBin
		ifTrue:
			[subMenu add: 'stop being a parts bin' action: #toggleIsPartsBin]
		ifFalse:
			[subMenu add: 'start being a parts bin' action: #toggleIsPartsBin].
	(self resizeToFit & self indicateCursor & self autoLineLayout) ifFalse:
		[subMenu add: 'behave like a Holder' action: #behaveLikeHolder].

	self backgroundSketch ifNotNil: [subMenu add: 'delete background painting' action: #deleteBackgroundPainting].
	menu add: 'playfield options...' subMenu: subMenu.
	menu addLine