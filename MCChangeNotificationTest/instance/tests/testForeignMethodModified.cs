testForeignMethodModified
	| event |
	event := self modifiedEventFor: #foreignMethod ofClass: self class.
	workingCopy methodModified: event.
	self deny: workingCopy modified