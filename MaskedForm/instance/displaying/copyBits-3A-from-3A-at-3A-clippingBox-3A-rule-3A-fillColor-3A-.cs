copyBits: copyRect from: sourceForm at: destPoint clippingBox: clipRect rule: rule fillColor: fillColor 
	"Do the same transformation to both theForm and mask.  If not what you want, do them separately.  6/20/96 tk"

	| sourceFigure sourceShape |
	(sourceForm isMemberOf: MaskedForm)
		ifTrue:
			[sourceFigure _ sourceForm theFormReally.
			sourceShape _ sourceForm mask]
		ifFalse: [sourceFigure _ sourceShape _ sourceForm].
	theForm copyBits: copyRect
		from: sourceFigure
		at: destPoint
		clippingBox: clipRect
		rule: rule
		fillColor: fillColor.
	mask copyBits: copyRect
		from: sourceShape
		at: destPoint
		clippingBox: clipRect
		rule: rule
		fillColor: fillColor