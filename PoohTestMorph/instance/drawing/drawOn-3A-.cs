drawOn: aCanvas
	| ptList last |
	super drawOn: aCanvas.
	aCanvas translateBy: bounds origin clippingTo: self innerBounds during:[:cc|
		points ifNotNil:[
			points class == Array 
				ifTrue:[ptList _ points]
				ifFalse:[ptList _ points contents].
			last _ ptList last.
				ptList do:[:next|
					cc line: last to: next width: 5 color: (Color gray: 0.9).
					last _ next]].
		self drawSubdivisionTrianglesOn: cc.
		self drawSubdivisionEdgesOn: cc.
		self drawSubdivisionSpineOn: cc.
	].
	time ifNotNil:[
		aCanvas drawString: time printString,' msecs' in: self innerBounds font: nil color: Color black.
	].