addCustomMenuItems: aCustomMenu hand: aHandMorph
	self isCurrentlyTextual
		ifTrue:
			[aCustomMenu add: 'change tab wording...' action: #changeTabText.
			aCustomMenu add: 'use graphical tab' action: #useGraphicalTab]
		ifFalse:
			[aCustomMenu add: 'use textual tab' action: #useTextualTab.
			aCustomMenu add: 'change tab graphic' action: #changeTabGraphic]