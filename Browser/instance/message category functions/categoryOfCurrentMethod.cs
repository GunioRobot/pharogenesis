categoryOfCurrentMethod
	"Determine the method category associated with the receiver.  If there is a method currently selected, answer its category.  If no that owns the current method.  Return the category name."

	| aCategory |
	^ super categoryOfCurrentMethod ifNil:
		[(aCategory _ self messageCategoryListSelection) == ClassOrganizer allCategory
					ifTrue:
						[nil]
					ifFalse:
						[aCategory]]