initialize 
	"Refer to the comment in View|initialize."
	super initialize.
	labelFrame _ Quadrangle new.
	labelFrame region: (Rectangle origin: 0 @ 0 extent: 50 @ self labelHeight).
	labelFrame borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	self label: nil.
	isLabelComplemented _ false.
	minimumSize _ 50 @ 50.
	maximumSize _ Display extent.
	collapsedViewport _ nil.
	expandedViewport _ nil.
	bitsValid _ false.
	updatablePanes _ #()