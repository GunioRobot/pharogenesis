addBookMenuItemsTo: aCustomMenu hand: aHandMorph
	(self hasSubmorphWithProperty: #pageControl)
		ifTrue: [aCustomMenu add: 'hide page controls' action: #hidePageControls]
		ifFalse: [aCustomMenu add: 'show page controls' action: #showPageControls]