showHomeCategory
	"Continue to show the current selector, but show it within the context of its primary category"

	| aSelector |
	(aSelector := self selectedMessageName) ifNotNil:
		[self preserveSelectorIfPossibleSurrounding:
			[self setToShowSelector: aSelector]]