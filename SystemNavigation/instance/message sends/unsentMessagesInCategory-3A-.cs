unsentMessagesInCategory: category
	^(SystemOrganization classesInCategory: category) inject: Set new into: [:unsentMessages :class|
		unsentMessages, (self unsentMessagesInClass: class)]
	