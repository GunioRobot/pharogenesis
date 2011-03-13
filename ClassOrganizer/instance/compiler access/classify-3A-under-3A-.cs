classify: element under: heading 
	"Store the argument, element, in the category named heading."

	| catName catIndex elemIndex realHeading |
	((heading = NullCategory) or: [heading == nil])
		ifTrue: [realHeading _ Default]
		ifFalse: [realHeading _ heading asSymbol].
	(catName _ self categoryOfElement: element) = realHeading
		ifTrue: [^self].  "done if already under that category"

	catName ~~ nil ifTrue: 
		[realHeading = Default
			ifTrue: [^self].	"return if exists and realHeading is default"
		self removeElement: element].	"remove if in another category"

	(categoryArray indexOf: realHeading) = 0 ifTrue: [self addCategory: realHeading].
	"add realHeading if not there already"

	catIndex _ categoryArray indexOf: realHeading.
	elemIndex _ 
		catIndex > 1
			ifTrue: [categoryStops at: catIndex - 1]
			ifFalse: [0].
	[(elemIndex _ elemIndex + 1) <= (categoryStops at: catIndex) 
		and: [element >= (elementArray at: elemIndex)]] whileTrue.

	"elemIndex is now the index for inserting the element. Do the insertion before it."
	elementArray _ elementArray copyReplaceFrom: elemIndex to: elemIndex-1
						with: (Array with: element).

	"add one to stops for this and later categories"
	catIndex to: categoryArray size do: 
		[:i | categoryStops at: i put: (categoryStops at: i) + 1].
	(self listAtCategoryNamed: Default) size = 0 ifTrue: [self removeCategory: Default]