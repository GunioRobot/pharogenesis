categoryList
	"Answer a list of categories for the categories pane."
	mailDB ifNil: [ ^#() ].
	^ mailDB allCategories
