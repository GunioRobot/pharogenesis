cursorOnBorder 
	| cp i box |
	view isCollapsed ifTrue: [^ false].
	cp := sensor cursorPoint.
	((view labelDisplayBox insetBy: (0@2 corner: 0@-2)) containsPoint: cp)
		ifTrue: [^ false].
	(i := view subViews findFirst: [:v | v displayBox containsPoint: cp]) = 0
		ifTrue: [box := view windowBox]
		ifFalse: [box := (view subViews at: i) insetDisplayBox].
	^ ((box insetBy: 3) containsPoint: cp) not
		and: [(box expandBy: 4) containsPoint: cp]