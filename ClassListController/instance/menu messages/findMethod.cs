findMethod
	"Pop up a list of the current class's methods, and select the one chosen by the user.
	5/21/96 sw, based on a suggestion of John Maloney's."

	| aClass selectors reply cat messageCategoryListIndex messageListIndex |
	self controlTerminate.

	model classListIndex = 0 ifTrue: [^ self].
	model okToChange ifFalse: [^ self].
	aClass _ model selectedClassOrMetaClass.
	selectors _ aClass selectors asSortedArray.
	reply _ (SelectionMenu labelList: selectors selections: selectors) startUp.
	reply == nil ifTrue: [^ self].
	cat _ aClass whichCategoryIncludesSelector: reply.
	messageCategoryListIndex _ model messageCategoryList indexOf: cat.
	model messageCategoryListIndex: messageCategoryListIndex.
	messageListIndex _ (model messageList indexOf: reply).
	model messageListIndex: messageListIndex.
	self controlInitialize.
