adjustPasteUpSize

	| newBottom |

	thePasteUp ifNil: [^self].
	newBottom _ thePasteUp bottom max: thePasteUp boundingBoxOfSubmorphs bottom + 20.
	thePasteUp height: (newBottom - thePasteUp top max: self height).
	thePasteUp width: (thePasteUp width max: scroller innerBounds width - 5).