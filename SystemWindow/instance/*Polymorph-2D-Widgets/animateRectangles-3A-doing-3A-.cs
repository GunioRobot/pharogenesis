animateRectangles: rects doing: aBlock
	"Animate the given rectangles."
	
	|rectMorph|
	rectMorph := RectangleMorph new
		color: Color transparent;
		setProperty: #morphicLayerNumber toValue: 12;
		openInWorld.
	rects withIndexDo: [:r :i |
		rectMorph bounds: r rounded.
		aBlock value: rectMorph value: i.
		World doOneCycle.
		(Delay forMilliseconds: 1) wait].
	rectMorph delete