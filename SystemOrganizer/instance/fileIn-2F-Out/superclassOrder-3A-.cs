superclassOrder: category 
	"Answer an OrderedCollection containing references to the classes in the 
	category whose name is the argument, category (a string). The classes 
	are ordered with superclasses first so they can be filed in."

	| list |
	list _ 
		(self listAtCategoryNamed: category asSymbol) 
			collect: [:title | Smalltalk at: title].
	^ChangeSet superclassOrder: list