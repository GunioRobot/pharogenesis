containsPoint: aPoint
	(super containsPoint: aPoint) ifTrue: [^ true].
	"Also include scrollbar when it is extended..."
	^ (retractableScrollBar and: [submorphs includes: scrollBar]) and:
		[scrollBar containsPoint: aPoint]