drawBorderOn: aCanvas
	"Display my border on the canvas."
	| lineColor bevel topLeftColor bottomRightColor bigClipRect brush p1i p2i |
	(borderColor == nil or: [borderColor isColor and: [borderColor isTransparent]])
		ifTrue: [^ self].
	lineColor _ borderColor.
	bevel _ false.
	"Border colors for bevelled effects depend on CW ordering of vertices"
	borderColor == #raised ifTrue: 
			[topLeftColor _ color lighter.
			bottomRightColor _ color darker.
			bevel _ true].
	borderColor == #inset ifTrue: 
			[topLeftColor _ owner colorForInsets darker.
			bottomRightColor _ owner colorForInsets lighter.
			bevel _ true].
	bigClipRect _ aCanvas clipRect expandBy: self borderWidth + 1 // 2.
	brush _ nil.
	self
		lineSegmentsDo: 
			[:p1 :p2 | 
			p1i _ p1 asIntegerPoint.
			p2i _ p2 asIntegerPoint.
			(closed or: ["bigClipRect intersects: (p1i rect: p2i) optimized:"
				((p1i min: p2i)
					max: bigClipRect origin)
					<= ((p1i max: p2i)
							min: bigClipRect corner)])
				ifTrue: 
					[bevel
						ifTrue: [(p1i quadrantOf: p2i)
								> 2
								ifTrue: [lineColor _ topLeftColor]
								ifFalse: [lineColor _ bottomRightColor]].
					(borderWidth > 3 and: [borderColor isColor])
						ifTrue: 
							[brush == nil ifTrue: [brush _ (ColorForm dotOfSize: borderWidth)
											colors: (Array with: Color transparent with: borderColor)].
							aCanvas
								line: p1i
								to: p2i
								brushForm: brush]
						ifFalse: [aCanvas
								line: p1i
								to: p2i
								width: borderWidth
								color: lineColor]]].
