removeServer

	| choice names |
	self flag: #ViolateNonReferenceToOtherClasses.
	names := ServerDirectory serverNames asSortedArray.
	choice := (SelectionMenu labelList: names selections: names) startUp.
	choice == nil ifTrue: [^ self].
	ServerDirectory removeServerNamed: choice