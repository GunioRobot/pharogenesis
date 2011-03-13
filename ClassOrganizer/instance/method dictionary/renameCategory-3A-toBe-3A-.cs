renameCategory: oldCatString toBe: newCatString
	"Rename a category. No action if new name already exists,
	or if old name does not exist."
	| index oldCategory newCategory |
	oldCategory _ oldCatString asSymbol.
	newCategory _ newCatString asSymbol.
	(categoryArray indexOf: newCategory) > 0
		ifTrue: [^self].	"new name exists, so no action"
	(index _ categoryArray indexOf: oldCategory) = 0
		ifTrue: [^self].	"old name not found, so no action"
	categoryArray at: index put: newCategory