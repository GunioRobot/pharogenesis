translationsKeystroke: aChar 
	"Respond to a Command key in the translations list."
	aChar == $x
		ifTrue: [^ self removeTranslation].
	aChar == $E
		ifTrue: [^ self browseMethodsWithTranslation]