showCategoriesPane
	"Show the categories pane instead of the search pane"

	| aPane |
	(aPane := self searchPane) ifNil: [^ Beeper beep].
	self containingWindow replacePane: aPane with: self newCategoryPane.
	categoryList := nil.
	self changed: #categoryList.
	self changed: #messageList