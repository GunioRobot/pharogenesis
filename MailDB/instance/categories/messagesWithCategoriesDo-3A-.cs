messagesWithCategoriesDo: aBlock
	self categorizer itemsWithCategoriesDo: [:msgID :categoryName | aBlock value: (self getMessage: msgID) value: categoryName].
