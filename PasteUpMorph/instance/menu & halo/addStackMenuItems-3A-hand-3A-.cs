addStackMenuItems: menu hand: aHandMorph
	| subMenu |
	self isStackLike
		ifTrue:
			[subMenu _ MenuMorph new defaultTarget: self.
			subMenu add: 'new card' action: #newCard.
			subMenu add: 'delete this card' action: #deleteCard.
			subMenu add: 'go to next card' action: #goToNextCard.
			subMenu add: 'go to previous card' action: #goToPreviousCard.
			menu add: 'card & stack...' subMenu: subMenu]
		ifFalse:
			[menu add: 'become a stack' action: #becomeStack]