toggleSearch
	"Toggle the determination of whether a categories pane or a search pane shows"

	self hasSearchPane
		ifTrue:	[self showCategoriesPane]
		ifFalse:	[self showSearchPane]