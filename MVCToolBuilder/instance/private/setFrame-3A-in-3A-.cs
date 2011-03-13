setFrame: aRectangle in: widget
	| win |
	aRectangle ifNil:[^nil].
	win := self asWindow: aRectangle.
	widget window: win.