untranslatedKeystroke: aChar 
	"Respond to a Command key in the translations list."
	aChar == $t
		ifTrue: [^ self translate].
	aChar == $E
		ifTrue: [^ self browseMethodsWithUntranslated]