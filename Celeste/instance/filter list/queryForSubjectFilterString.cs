queryForSubjectFilterString
	| subject guess |
	guess := currentMsgID isNil 
				ifTrue: ['']
				ifFalse: [(mailDB getTOCentry: currentMsgID) subject].
	guess := self normalizedSubject: guess.
	
	subject := FillInTheBlank request: 'Subject filter pattern?'
				initialAnswer: guess.
	subject ifNotNil: 
			[subject := subject withBlanksTrimmed.
			subject isEmpty ifTrue: [subject := nil]].
	^subject