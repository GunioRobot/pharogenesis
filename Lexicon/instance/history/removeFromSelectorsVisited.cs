removeFromSelectorsVisited
	"Remove the currently-selected method from the active set"

	| aSelector |
	(aSelector := self selectedMessageName) ifNil: [^ self].
	self removeFromSelectorsVisited: aSelector.
	self chooseCategory: self class viewedCategoryName