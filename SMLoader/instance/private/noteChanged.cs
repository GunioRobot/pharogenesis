noteChanged
	packagesList := nil.
	selectedCategoryWrapper := nil.
	filters ifNil: [^self reOpen].
	self changed: #categoryWrapperList.
	self changed: #packageWrapperList.
	self changed: #packagesListIndex.	"update my selection"
	self contentsChanged