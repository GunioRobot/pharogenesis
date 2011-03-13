buildHandleMenu: aHand
	"Build the morph menu for the given morph's halo's menu handle. This menu has two sections. The first section contains commands that are interpreted by the hand; the second contains commands provided by the target morph. This method allows the morph to decide which items should be included in the hand's section of the menu."

	| menu |
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.
	self addAddHandMenuItemsForHalo: menu hand: aHand.
	menu defaultTarget: self.
	self addCustomHaloMenuItems: menu hand: aHand.
	menu addLine.
	self player ifNotNil: [self player addPlayerMenuItemsTo: menu hand: aHand].
	menu defaultTarget: aHand.
	^ menu
