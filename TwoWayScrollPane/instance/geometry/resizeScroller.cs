resizeScroller
	| inner |
	"used to handle left vs right scrollbar"
	inner _ self innerBounds.
	scroller bounds: (inner topLeft + (16@0) corner: (inner bottomRight - (0@16)))