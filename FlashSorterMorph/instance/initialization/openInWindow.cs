openInWindow
	| window wrapper |
	window := SystemWindow new.
	wrapper := self makeControls.
	window addMorph: wrapper frame: (0@0 extent: 1@0.1).
	wrapper := ScrollPane new.
	wrapper scroller: self.
	window addMorph: wrapper frame: (0 @ 0.1 extent: 1 @ 1).
	self bounds: owner bounds.
	self doLayout.
	window openInWorld.