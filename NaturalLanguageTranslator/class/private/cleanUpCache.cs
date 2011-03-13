cleanUpCache
	"NaturalLanguageTranslator cleanUpCache"

	self cachedTranslations keys do: [:key |
		key isoLanguage size > 2 ifTrue: [self cachedTranslations removeKey: key]]