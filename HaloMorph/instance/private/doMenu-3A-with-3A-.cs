doMenu: evt with: menuHandle
	"Ask hand to invoke the halo menu for my inner target."

	| menu |
	self removeAllHandlesBut: nil.  "remove all handles"
	self world displayWorld.
	menu _ evt hand buildMorphHandleMenuFor: innerTarget.
	target addDropShadowItemsTo: menu hand: evt hand.
	innerTarget addTitleForHaloMenu: menu.
	evt hand invokeMenu: menu event: evt.
