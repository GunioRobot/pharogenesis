cursorOnBorder 
	| cp i box |
	view isCollapsed ifTrue: [^ false].
	cp _ sensor cursorPoint.
	((view labelDisplayBox insetBy: (0@2 corner: 0@-2)) containsPoint: cp)
		ifTrue: [^ false].
	(i _ view subViews findFirst: [:v | v displayBox containsPoint: cp]) = 0
		ifTrue: [box _ view windowBox]
		ifFalse: [box _ (view subViews at: i) insetDisplayBox].
	^ ((box insetBy: 3) containsPoint: cp) not
		and: [(box expandBy: 4) containsPoint: cp]