adjustBookControls
	| inner |
	prevButton ifNil: [^ self].
	prevButton align: prevButton topLeft with: (inner _ self innerBounds) topLeft + (32 @ -1).
	nextButton align: nextButton topRight with: inner topRight - (18 @ 1).
	menuButton align: menuButton topLeft with: inner topRight + (-42 @ 5).