translations
	"answet the translator's translations"
	| allTranslations filterString |
	allTranslations := self translator translations keys.
	""
	filterString := self translationsFilter.
	""
	filterString isEmpty
		ifFalse: [allTranslations := allTranslations
						select: [:each | ""
							('*' , filterString , '*' match: each)
								or: ['*' , filterString , '*'
										match: (self translator translationFor: each)]]].
""
	^ allTranslations asSortedCollection