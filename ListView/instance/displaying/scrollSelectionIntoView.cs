scrollSelectionIntoView
	"Selection is assumed to be on and clipped out of view.
	Uses controller scrollView to keep selection right"
	| delta |
	(delta := self insetDisplayBox bottom - self selectionBox bottom) < 0
		ifTrue: [^ self controller scrollView: delta - (list lineGrid-1)]. "up"
	(delta := self insetDisplayBox top - self selectionBox top) > 0
		ifTrue: [^ self controller scrollView: delta + 1] "down"