selectAndScrollToTop
	"Scroll until the selection is in the view and then highlight it."

	| lineHeight deltaY rect deltaX |
	lineHeight _ paragraph textStyle lineGrid.
	rect _ morph owner bounds.
	deltaY _ stopBlock top - rect top.
	deltaY ~= 0 ifTrue: [
		deltaX _ 0.
		deltaY _ (deltaY abs + lineHeight - 1 truncateTo: lineHeight) negated.
		morph editView scrollBy: deltaX@deltaY]