displayOn: aCanvas using: displayScanner at: somePosition
	"Send all visible lines to the displayScanner for display"
	| visibleRectangle offset leftInRun line |
	visibleRectangle _ aCanvas clipRect.
	offset _ (somePosition - positionWhenComposed) truncated.
	leftInRun _ 0.
	(self lineIndexForPoint: visibleRectangle topLeft)
		to: (self lineIndexForPoint: visibleRectangle bottomRight)
		do: [:i | line _ lines at: i.
			self displaySelectionInLine: line on: aCanvas.
			line first <= line last ifTrue:
				[leftInRun _ displayScanner displayLine: line
								offset: offset leftInRun: leftInRun]].
