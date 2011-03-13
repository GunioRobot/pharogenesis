exportCategoryNamed: catName
	"CodeLoader exportCategoryNamed: 'OceanicPanic' "

	| list |
	list _ SystemOrganization listAtCategoryNamed: catName asSymbol.
	self exportClassesNamed: list to: catName