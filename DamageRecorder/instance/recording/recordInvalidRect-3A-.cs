recordInvalidRect: aRectangle
	"Record the given rectangle in my damage list, a list of rectangular areas of the display that should be redraw on the next display cycle."
	"Details: Damaged rectangles are often identical or overlap significantly. In these cases, we merge them to reduce the number of damage rectangles that must be processed when the display is updated. Moreover, above a certain threshold, we ignore the individual rectangles completely, and simply do a complete repaint on the next cycle."

	| mergeRect |
	totalRepaint ifTrue: [^ self].  "planning full repaint; don't bother collecting damage"

	invalidRects do: [:rect |
		(rect intersects: aRectangle) ifTrue: [
			"merge rectangle in place (see note below) if there is any overlap"
			rect setOrigin: (rect origin min: aRectangle origin) truncated
				corner: (rect corner max: aRectangle corner) truncated.
			^ self]].


	invalidRects size >= 15 ifTrue: [
		"if there are too many separate areas, just repaint all"
		"totalRepaint _ true."
"Note:  The totalRepaint policy has poor behavior when many local rectangles (such as parts of a text selection) force repaint of the entire screen.  As an alternative, this code performs a simple merge of all rects whenever there are more than 10."
		mergeRect _ Rectangle merging: invalidRects.
		self reset.
		invalidRects addLast: mergeRect].

	"add the given rectangle to the damage list"
	"Note: We make a deep copy of all rectangles added to the damage list,
	 since rectangles in this list may be extended in place."
	invalidRects addLast: (aRectangle topLeft truncated corner: aRectangle bottomRight truncated).
