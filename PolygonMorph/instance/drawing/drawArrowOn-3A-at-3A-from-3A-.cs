drawArrowOn: aCanvas at: endPoint from: priorPoint 
	"Draw a triangle oriented along the line from priorPoint to  
	endPoint. Answer the wingBase."

	| pts spec wingBase |
	pts := self arrowBoundsAt: endPoint from: priorPoint.
	wingBase := pts size = 4 
				ifTrue: [pts third]
				ifFalse: [(pts copyFrom: 2 to: 3) average].
	spec := self valueOfProperty: #arrowSpec ifAbsent: [5 @ 4].
	spec x sign = spec y sign 
		ifTrue: [aCanvas drawPolygon: pts fillStyle: borderColor]
		ifFalse: 
			[aCanvas 
				drawPolygon: pts
				fillStyle: Color transparent
				borderWidth: (borderWidth + 1) // 2
				borderColor: borderColor].
	^wingBase