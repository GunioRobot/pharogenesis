updatePanes
	| count |
	model ifNil: [panes := Array new. ^ self].
	count := panes ifNotNil: [panes size] ifNil: [0].
	self basicUpdatePanes.
	self basicUpdateSizing.	
	self layoutPanes.
	panes size = count
		ifFalse: [self hideOrShowScrollBar.
				self setScrollDeltas].
	panes size > count ifTrue: [self scrollToRight].
	^ panes