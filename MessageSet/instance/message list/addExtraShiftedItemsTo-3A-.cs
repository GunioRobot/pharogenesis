addExtraShiftedItemsTo: aMenu
	"The shifted selector-list menu is being built.  Add items specific to MessageSet"

	self growable ifTrue:
		[aMenu addList: #(
			-
			('remove from this browser'		removeMessageFromBrowser)
			('filter message list...'			filterMessageList)
			('add to message list...'			augmentMessageList))].
	aMenu add: 'sort by date' action: #sortByDate