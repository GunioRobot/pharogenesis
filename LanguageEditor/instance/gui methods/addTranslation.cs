addTranslation
	"translate a phrase"
	| phrase |
	phrase := UIManager default
				request: 'enter the original:'
				initialAnswer: ''.

	phrase isEmptyOrNil
		ifTrue: [""
			self beep.
			^ self].
	""
	self translatePhrase: phrase