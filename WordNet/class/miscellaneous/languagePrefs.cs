languagePrefs
	"Set preference of which natural language is primary. Look up definitions in it, and correct speaLanguageing in it.  Also, let user set languages to translate from and to."

	| ch aLanguage |
	self canTranslateFrom.		"sets defaults"
	ch _ PopUpMenu withCaption: 'Choose the natural language to use for:'
			chooseFrom: 'word definition and spelling verification (', 
					(Preferences parameterAt: #myLanguage ifAbsentPut: [#English]) asString ,')...\',
				'language to translate FROM   (now ',
					(Preferences parameterAt: #languageTranslateFrom ifAbsentPut: [#English]) asString ,')...\',
				'language to translate TO   (now ',
					(Preferences parameterAt: #languageTranslateTo ifAbsentPut: [#German]) asString ,')...\'.
	ch = 1 ifTrue: [
		aLanguage _ PopUpMenu withCaption: 'The language for word definitions and speaLanguageing verification:'
			chooseFrom: Languages.
		aLanguage > 0 ifTrue:
			[^ Preferences setParameter: #myLanguage to: (Languages at: aLanguage) asSymbol]].
	ch = 2 ifTrue:
		[aLanguage _ PopUpMenu withCaption: 'The language to translate from:'
			chooseFrom: CanTranslateFrom.
		aLanguage > 0 ifTrue:
			[^ Preferences setParameter: #languageTranslateFrom to: (CanTranslateFrom at: aLanguage) asSymbol]].
	ch = 3 ifTrue:
		[aLanguage _ PopUpMenu withCaption: 'The language to translate to'
			chooseFrom: CanTranslateFrom.
		aLanguage > 0 ifTrue:
			[^ Preferences setParameter: #languageTranslateTo to: (CanTranslateFrom at: aLanguage) asSymbol]].

	"Maybe let the user add another language if he knows the server can take it."
"	ch _ (PopUpMenu labelArray: Languages, {'other...'.
			'Choose language to translate from...'})
		startUpWithCaption: 'Choose the language of dictionary for word definitions.'.
	ch = 0 ifTrue: [^ Preferences setParameter: #myLanguage to: #English].
	(ch <= Languages size) ifTrue: [aLanguage _ Languages at: ch].
	ch = (Languages size + 1) ifTrue: [
		aLanguage _ FillInTheBlank request: 'Name of the primary language'].
	aLanguage ifNotNil: [^ Preferences setParameter: #myLanguage to: aLanguage asSymbol].
"