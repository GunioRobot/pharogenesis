additionsToViewerCategory: aCategoryName
	"Answer a list of viewer specs for items to be added to the given category on behalf of the receiver.  Each class in a morph's superclass chain is given the opportunity to add more things"

	self additionsToViewerCategories do:
		[:anAddition | anAddition first == aCategoryName ifTrue: [^ anAddition second]].
	^ #()