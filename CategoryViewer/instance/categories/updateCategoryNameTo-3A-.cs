updateCategoryNameTo: aName
	"Update the category name, because of a language change."

	| actualPane |
	(actualPane _ namePane firstSubmorph) contents: aName; color: Color black.
	namePane extent: actualPane extent.
	self world ifNotNil: [self world startSteppingSubmorphsOf: self]
