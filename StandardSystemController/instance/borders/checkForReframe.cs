checkForReframe
	| cp |
	view isCollapsed ifTrue: [^ self].
	cp := sensor cursorPoint.
	((view closeBoxFrame expandBy: 2) containsPoint: cp)
		| ((view growBoxFrame expandBy: 2) containsPoint: cp)
		ifTrue: [^ self].  "Dont let reframe interfere with close/grow"
	self adjustWindowCorners.
	self cursorOnBorder ifFalse: [^ self].
	((view insetDisplayBox insetBy: 2@2) containsPoint: cp)
		ifFalse: [^ self adjustWindowBorders].
	view subViews size <= 1 ifTrue: [^ self].
	(view subviewWithLongestSide: [:s | ] near: cp) == nil
		ifFalse: [^ self adjustPaneBorders].