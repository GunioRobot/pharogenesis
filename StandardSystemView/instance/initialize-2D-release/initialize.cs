initialize 
	"Refer to the comment in View|initialize."
	super initialize.
	labelFrame := Quadrangle new.
	labelFrame region: (Rectangle origin: 0 @ 0 extent: 50 @ self labelHeight).
	labelFrame borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	self label: nil.
	isLabelComplemented := false.
	minimumSize := 50 @ 50.
	maximumSize := Display extent.
	collapsedViewport := nil.
	expandedViewport := nil.
	bitsValid := false.
	updatablePanes := #()