removeServer
	| choice names |
	names _ ServerDirectory serverNames asSortedArray.
	choice _ (SelectionMenu labelList: names selections: names) startUp.
	choice == nil ifTrue: [^ self].
	ServerDirectory removeServerNamed: choice