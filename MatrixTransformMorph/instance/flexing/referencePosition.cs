referencePosition
	| refPos |
	refPos _ self valueOfProperty: #referencePosition.
	refPos ifNil:[refPos _ self transform globalPointToLocal: super referencePosition].
	^self transformFromWorld localPointToGlobal: refPos