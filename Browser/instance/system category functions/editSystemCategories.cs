editSystemCategories
	"Retrieve the description of the class categories of the system organizer."

	self okToChange ifFalse: [^ self].
	self systemCategoryListIndex: 0.
	editSelection _ #editSystemCategories.
	self changed: #editSystemCategories.
	self changed: #contents