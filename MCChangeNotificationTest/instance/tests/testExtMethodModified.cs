testExtMethodModified
	| event |
	event := self modifiedEventFor: #asClassDefinition ofClass: Class.
	workingCopy methodModified: event.
	self assert: workingCopy modified