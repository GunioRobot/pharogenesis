showOptions
	"The receiver is a tile that represents an operator; a click on the 
	receiver's label will pop up a menu of alternative operator choices"
	| result menuChoices word |
	menuChoices _ (self options first collect: [:each | each asString translated]) collect: [:each | 
							word := self currentVocabulary translatedWordingFor: each asSymbol.
							word isEmpty
								ifTrue: ['<-']
								ifFalse: [word]].
	result _ (SelectionMenu labelList: menuChoices lines: nil selections: self options first) startUp.
	result 
		ifNotNil: [self value: result.
			self scriptEdited]