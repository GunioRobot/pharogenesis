toggleUserInterfaceString
	^UseScaffoldingInterface 
		ifTrue: [ 'switch to expert interface' ]
		ifFalse: [ 'switch to basic interface' ]