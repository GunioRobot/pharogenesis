edit
	"Present the categories of system classes so that the user can view and 
	edit them."

	view singleItemMode ifTrue: [^view flash].
	self controlTerminate.
	model editSystemCategories.
	self controlInitialize