mouseDown: evt
	"Handle a mouse down event. Menu items get activated when the mouse is over them."

	self isInMenu ifFalse: [^ super mouseDown: evt].
	evt shiftPressed ifTrue: [^ super mouseDown: evt].  "enable label editing" 
	(owner hasProperty: #paletteMenu)
		ifFalse:
			[self bringMenuChainToFront].
	self selectFromHand: evt hand
