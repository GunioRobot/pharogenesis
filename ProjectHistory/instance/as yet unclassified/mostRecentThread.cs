mostRecentThread

	| projectNames threadName |
	self cleanUp.
	projectNames _ (mostRecent collect: [ :each | {each first} ]) reversed.

	threadName _ FillInTheBlank 
		request: 'Please name this thread.' 
		initialAnswer: 'Recent projects @ ',Time now printString.
	threadName isEmptyOrNil ifTrue: [^nil].
	InternalThreadNavigationMorph know: projectNames as: threadName.
	^threadName
