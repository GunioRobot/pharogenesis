setPageColor
	"Get a color from the user, then set all the pages to that color"

	self currentPage ifNil: [^ self].
	ColorPickerMorph new
		sourceHand: self activeHand;
		target: self;
		selector: #setAllPagesColor:;
		originalColor: self currentPage color;
		addToWorld: self world
			near: self fullBounds