translation
	"answer the translation for the selected phrase"
	self selectedTranslation isZero
		ifTrue: [^ '<select a phrase from the upper list>' translated].
	""
	^ self translator
		translationFor: (self translations at: self selectedTranslation)