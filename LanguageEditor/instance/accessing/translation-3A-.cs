translation: aStringOrText 
	"change the translation for the selected phrase"
	| phrase |
	self selectedTranslation isZero
		ifTrue: [^ self].
	phrase _ self translations at: self selectedTranslation.
	translator
		phrase: phrase
		translation: aStringOrText asString.
	newerKeys add: phrase.
	^ true