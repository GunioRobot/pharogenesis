exportCategories: catList to: aFileName
	"CodeLoader exportCategories: #( 'Game-Animation' 'Game-Framework' ) to: 'Game-Framework'"

	| list classList |
	classList _ OrderedCollection new.
	catList do: [:catName |
		list _ SystemOrganization listAtCategoryNamed: catName asSymbol.
		list do: [:nm | classList add: (Smalltalk at: nm); add: (Smalltalk at: nm) class]].
	self exportCodeSegment: aFileName classes: classList keepSource: true