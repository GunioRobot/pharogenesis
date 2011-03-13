testLocaleChanged
	"self debug: #testLocaleChanged"
	"LanguageEnvironment >> startUp is called from Prject >> localeChanged"
	Project current updateLocaleDependents.
	self assert: (ActiveHand instVarNamed: 'keyboardInterpreter') isNil.
	self assert: (Clipboard default instVarNamed: 'interpreter') isNil.
	Locale switchToID: (LocaleID isoLanguage: 'ja').
	self assert: Preferences useFormsInPaintBox.
	Locale switchToID: (LocaleID isoLanguage: 'en').
	self assert: Preferences useFormsInPaintBox not.
