totalScrollRange

	"Return the entire scrolling range."
	^ ((scroller submorphBounds ifNil: [^nil]) encompass: 0@0) extent

