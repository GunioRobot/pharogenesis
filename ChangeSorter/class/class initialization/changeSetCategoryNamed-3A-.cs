changeSetCategoryNamed: aName
	"Answer the changeSetCategory of the given name, or nil if none"

	^ ChangeSetCategories elementAt: aName asSymbol 