updateLiteralLabel
	"Update the wording emblazoned on the tile, if needed"

	| myLabel |
	(myLabel _ self labelMorph) ifNil: [^ self].

	myLabel acceptValue:
		(type == #literal
			ifTrue:
				[literal] 
			ifFalse: [operatorReadoutString 
				ifNil:		[self currentEToyVocabulary tileWordingForSelector: operatorOrExpression]
				ifNotNil:  	[operatorReadoutString]]).
	self changed.