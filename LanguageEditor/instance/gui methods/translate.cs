translate
	"translate a phrase"
	| phrase |
	phrase := self phraseToTranslate.
	""
	(phrase isNil
			or: [phrase = ''])
		ifTrue: [""
			self beep.
			^ self].
	""
	self translatePhrase: phrase