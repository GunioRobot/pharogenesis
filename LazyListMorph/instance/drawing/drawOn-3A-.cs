drawOn: aCanvas
	| |
	listItems size = 0 ifTrue: [ ^self ].
 
	self drawSelectionOn: aCanvas.

	(self topVisibleRowForCanvas: aCanvas) to: (self bottomVisibleRowForCanvas: aCanvas) do: [ :row |
		(listSource itemSelectedAmongMultiple:  row) ifTrue: [
			self drawBackgroundForMulti: row on: aCanvas. ].
		self display: (self item: row) atRow: row on: aCanvas.
	].

	listSource potentialDropRow > 0 ifTrue: [
		self highlightPotentialDropRow: listSource potentialDropRow on: aCanvas ].