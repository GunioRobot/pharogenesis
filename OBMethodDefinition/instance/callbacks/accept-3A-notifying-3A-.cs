accept: aText notifying: aController
	| newSelector |
	newSelector := self compileMethod: aText notifying: aController.
	newSelector ifNil: [^ false].
	(self nodeFor: newSelector) demandSelection.
	^ true