testCoreMethodModified
	| event |
	event := self modifiedEventFor: #one ofClass: MCMockClassA.
	workingCopy methodModified: event.
	self assert: workingCopy modified