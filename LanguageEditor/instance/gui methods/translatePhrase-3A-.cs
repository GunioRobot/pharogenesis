translatePhrase: aString 
	"translate aString"
	| translation |
	translation := FillInTheBlank
				multiLineRequest: 'translation for: ' translated , '''' , aString , ''''
				centerAt: Sensor cursorPoint
				initialAnswer: aString
				answerHeight: 200.
	""
	(translation isNil
			or: [translation = ''])
		ifTrue: [""
			self beep.
			^ self].
	""
	self phrase: aString translation: translation