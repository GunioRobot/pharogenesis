untranslated
	"answer the translator's untranslated phrases"
	

| all filterString |
	all := self translator untranslated.
	""
	filterString := self untranslatedFilter.
	""
	filterString isEmpty
		ifFalse: [all := all
						select: [:each | ""
							('*' , filterString , '*' match: each)
								or: ['*' , filterString , '*'
										match: (self translator translationFor: each)]]].
	""
	^ all asSortedCollection