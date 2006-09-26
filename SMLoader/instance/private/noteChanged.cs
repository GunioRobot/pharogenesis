noteChanged
	filters ifNil: [^self reOpen].
	model ifNotNil: [
		packagesList := nil.
		selectedCategoryWrapper := nil.
		self changed: #categoryWrapperList.
		self changed: #packageWrapperList.
		self changed: #packagesListIndex.	"update my selection"
		self contentsChanged]