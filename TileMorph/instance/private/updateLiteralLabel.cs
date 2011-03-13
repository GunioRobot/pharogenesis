updateLiteralLabel
	"now works for operator tiles also"

	|  desiredW leader myLabel |
	(myLabel _ self labelMorph) ifNil: [^ self].
	myLabel contents:
		(type == #literal
			ifTrue:
				[literal stringForReadout] 
			ifFalse: [operatorReadoutString 
				ifNil:		[ScriptingSystem wordingForOperator: operatorOrExpression]
				ifNotNil:  	[operatorReadoutString]]).

	leader _ (upArrow ifNil: [0] ifNotNil: [UpArrowAllowance]) + 4.
	desiredW _ leader + myLabel width.
	suffixArrow ifNotNil: [desiredW _ desiredW + SuffixArrowAllowance].
	self extent: (desiredW max: self minimumWidth) @ self class defaultH.
	myLabel position: (self left + (leader + 0)) @ (bounds top + 5); fullBounds.
	suffixArrow ifNotNil: [suffixArrow align: suffixArrow topRight with:
				bounds topRight + (-2 @ (self height // 2)) - (0 @ (suffixArrow height // 2))].
	self changed