buildMessageCategoryListView: aBrowser

	| aMessageCategoryListView |
	aMessageCategoryListView _ MessageCategoryListView new.
	aMessageCategoryListView model: aBrowser.
	aMessageCategoryListView window: (0 @ 0 extent: 50 @ 70).
	aMessageCategoryListView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	^aMessageCategoryListView