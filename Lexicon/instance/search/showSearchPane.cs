showSearchPane
	"Given that the receiver is showing the categories pane, replace that with a search pane.  Though there is a residual UI for obtaining this variant, it is obscure and the integrity of the protocol-category-browser when there is no categories pane is not necessarily assured at the moment."

	| aPane |
	(aPane _ self categoriesPane) ifNil: [^ Beeper beep].
	self containingWindow replacePane: aPane with: self newSearchPane.
	categoryList _ nil.
	self changed: #categoryList.
	self changed: #messageList