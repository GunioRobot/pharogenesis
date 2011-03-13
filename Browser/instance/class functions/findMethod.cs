findMethod
	"Pop up a list of the current class's methods, and select the one chosen by the user.
	5/21/96 sw, based on a suggestion of John Maloney's."
	| aClass selectors reply cat messageCatIndex messageIndex |

	self classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	aClass _ self selectedClassOrMetaClass.
	selectors _ aClass selectors asSortedArray.
	reply _ (SelectionMenu labelList: selectors selections: selectors) startUp.
	reply == nil ifTrue: [^ self].
	cat _ aClass whichCategoryIncludesSelector: reply.
	messageCatIndex _ self messageCategoryList indexOf: cat.
	self messageCategoryListIndex: messageCatIndex.
	messageIndex _ (self messageList indexOf: reply).
	self messageListIndex: messageIndex.
