subViewSatisfying: aBlock
	"Return the first subview that satisfies aBlock, or nil if none does.  1/31/96 sw"

	^ subViews detect: [:aView | aBlock value: aView] ifNone: [nil]