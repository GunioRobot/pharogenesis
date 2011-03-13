initCheckMethods
	"LanguageEditor initCheckMethods"

	| registry |
	registry := Dictionary new.
	registry
		at: 'es' put: #checkSpanishPhrase:translation:;
		yourself.
	^registry