limitClass
	"Answer the limit class to use in this viewer"

	| aClass |
	(aClass _ self valueOfProperty: #limitClass)  ifNotNil:
		[^ aClass].

	aClass _ scriptedPlayer defaultLimitClassForVocabulary: self currentVocabulary.
	self setProperty: #limitClass toValue: aClass.
	^ aClass