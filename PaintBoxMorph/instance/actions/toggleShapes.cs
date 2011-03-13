toggleShapes
	| tab sh stamps |
	"The sub panel that has the shape tools on it.  Rect, line..."
	stamps _ self submorphNamed: 'stamps'.
	tab _ self submorphNamed: 'shapeTab'.
	(sh _ self submorphNamed: 'shapes') visible
		ifTrue: [sh hide.  tab top: stamps bottom-1]
		ifFalse: [sh comeToFront.  sh top: stamps bottom-9.  
				sh show.  tab top: sh bottom - tab height + 10].
	self layoutChanged.
