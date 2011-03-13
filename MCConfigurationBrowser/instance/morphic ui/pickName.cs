pickName
	| name |
	name := FillInTheBlank
		request: 'Name (.', self configuration writerClass extension, ' will be appended):'
		initialAnswer: (self configuration name ifNil: ['']).
	^ name isEmpty ifFalse: [name]