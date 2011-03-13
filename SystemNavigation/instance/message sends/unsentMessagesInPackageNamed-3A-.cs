unsentMessagesInPackageNamed: packageName
	| unsentMessages |
	unsentMessages := self unsentMessagesInCategory: packageName.	
	(SystemOrganization categoriesMatching: packageName, '-*') do: [:category|
		unsentMessages addAll: (self unsentMessagesInCategory: category)].
	^unsentMessages 
	