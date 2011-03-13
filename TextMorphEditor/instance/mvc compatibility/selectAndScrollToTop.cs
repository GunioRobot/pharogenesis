selectAndScrollToTop
	"Scroll until the selection is in the view and then highlight it."

	| lineHeight deltaY rect deltaX |
	lineHeight := paragraph textStyle lineGrid.
	rect := morph owner bounds.
	deltaY := self stopBlock top - rect top.
	deltaY ~= 0 ifTrue: [
		deltaX := 0.
		deltaY := (deltaY abs + lineHeight - 1 truncateTo: lineHeight) negated.
		morph editView scrollBy: deltaX@deltaY]