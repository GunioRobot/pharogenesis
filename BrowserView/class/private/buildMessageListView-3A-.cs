buildMessageListView: aBrowser
	| aMessageListView |

	aMessageListView _ MessageListView new.
	aMessageListView model: aBrowser.
	aMessageListView window: (0 @ 0 extent: 50 @ 70).
	aMessageListView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	^ aMessageListView