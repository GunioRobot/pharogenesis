addTranslation
	"translate a phrase"
	| phrase |
	phrase := UIManager default
				request: 'enter the original:'
				initialAnswer: ''.

	(phrase isNil
			or: [phrase = ''])
		ifTrue: [""
			self beep.
			^ self].
	""
	self translatePhrase: phrase