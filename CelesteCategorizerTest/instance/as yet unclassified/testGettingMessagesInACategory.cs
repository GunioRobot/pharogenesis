testGettingMessagesInACategory
	categorizer addCategory: 'aardvark'.
	self assert: (categorizer at: 'aardvark') isEmpty.  "The category was just created, so there are no messages in it."
