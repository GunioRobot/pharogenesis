newCategoryWithId: anIdString 
	"Create a category and add it to me.
	Clear the categories cache."

	categories _ nil.
	^self newObject: (SMCategory newIn: self withId: anIdString)