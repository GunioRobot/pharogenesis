selection: item
	"Called from outside to request setting a new selection.
	Assumes scroller submorphs is exactly our list"
	| index theMorph |
	index _ scroller submorphs findFirst: [:m | m contents = item].
	index = 0 ifTrue: [^ self selectedMorph: nil].
	theMorph _ scroller submorphs at: index.
		"Scroll into view -- should be elsewhere"
		scrollBar value: (((index-1 * theMorph height) / self totalScrollRange)
								truncateTo: scrollBar scrollDelta).
		scroller offset: -3 @ (self totalScrollRange * scrollBar value).
	self selectedMorph: theMorph