scrollToPage: pageNumber

	| rects oneRect |

	rects _ self valueOfProperty: #pageBreakRectangles ifAbsent: [#()].
	oneRect _ rects at: pageNumber - 1 ifAbsent: [0@0 extent: 0@0].
	self scrollToYAbsolute: oneRect bottom.
