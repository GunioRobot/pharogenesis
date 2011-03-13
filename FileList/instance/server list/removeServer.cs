removeServer

	| choice names |
	self flag: #ViolateNonReferenceToOtherClasses.
	names := ServerDirectory serverNames asSortedArray.
	choice := UIManager default chooseFrom: names values: names.
	choice ifNil: [^ self].
	ServerDirectory removeServerNamed: choice