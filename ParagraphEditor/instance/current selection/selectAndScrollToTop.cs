selectAndScrollToTop
	"Scroll until the selection is in the view and then highlight it."
	| lineHeight deltaY clippingRectangle |
	self select.
	lineHeight _ paragraph textStyle lineGrid.
	clippingRectangle _ paragraph clippingRectangle.
	deltaY _ self stopBlock top - clippingRectangle top.
	deltaY ~= 0 
		ifTrue: [self scrollBy: (deltaY abs + lineHeight - 1 truncateTo: lineHeight)
									* deltaY sign]