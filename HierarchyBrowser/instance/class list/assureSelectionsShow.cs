assureSelectionsShow
	"This is a workaround for the fact that a hierarchy browser, when launched, often does not show the selected class"

	| saveCatIndex saveMsgIndex |
	saveCatIndex _ messageCategoryListIndex.
	saveMsgIndex _ messageListIndex.
	self classListIndex: classListIndex.
	self messageCategoryListIndex: saveCatIndex.
	self messageListIndex: saveMsgIndex