makeJapaneseTranslationFile

	| t n |
	NaturalLanguageTranslator allKnownPhrases removeAll.
	t _ TranslatedReceiverFinder new senders.
	n _ NaturalLanguageTranslator localeID: (LocaleID isoLanguage: 'ja').

	t do: [:w |
		NaturalLanguageTranslator registerPhrase: w.
		self at: w ifPresent: [:k | n phrase: w translation: k].
	].
	n saveToFileNamed: 'ja.translation'.
 