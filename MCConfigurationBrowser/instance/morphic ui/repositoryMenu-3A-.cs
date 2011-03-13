repositoryMenu: aMenu
	^self fillMenu: aMenu fromSpecs: #(
		('add repository...' addRepository)
	)