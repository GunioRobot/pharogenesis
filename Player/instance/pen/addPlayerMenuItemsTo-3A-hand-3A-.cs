addPlayerMenuItemsTo: aMenu hand: aHandMorph
	| subMenu |
	"Note that all these items are now available in another way in an object's Viewer"

	(self slotInfo size > 0) ifTrue:
		[aMenu add: 'change variable type...' target: self action: #changeVariableType].

	subMenu _ MenuMorph new defaultTarget: self.
	self getPenDown
		ifTrue: [subMenu add: 'lift pen' action: #liftPen]
		ifFalse: [subMenu add: 'lower pen' action: #lowerPen].
	subMenu add: 'choose pen size...' action: #choosePenSize.
	subMenu add: 'choose pen color...' action: #choosePenColor:.
	aMenu add: 'pen...' subMenu: subMenu