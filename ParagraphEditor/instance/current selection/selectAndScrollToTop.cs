selectAndScrollToTop
	"Scroll until the selection is in the view and then highlight it."
	| lineHeight deltaY clippingRectangle |
	self select.
	lineHeight := paragraph textStyle lineGrid.
	clippingRectangle := paragraph clippingRectangle.
	deltaY := self stopBlock top - clippingRectangle top.
	deltaY ~= 0 
		ifTrue: [self scrollBy: (deltaY abs + lineHeight - 1 truncateTo: lineHeight)
									* deltaY sign]