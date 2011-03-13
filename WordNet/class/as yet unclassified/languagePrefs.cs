languagePrefs
	| ch ll |
	"Set preference of which natural language is primary. Look up definitions in it, and correct spelling in it.  Also, let user set languages to translate from and to."

	self canTranslateFrom.		"sets defaults"
	ch _ PopUpMenu withCaption: 'Choose the natural language to use for:'
			chooseFrom: 'word definition and spelling verification (', 
					(Preferences valueOfFlag: #myLanguage) asString ,')...\',
				'language to translate from (',
					(Preferences valueOfFlag: #languageTranslateFrom) asString ,')...\',
				'language to translate to (',
					(Preferences valueOfFlag: #languageTranslateTo) asString ,')...\'.
	ch = 1 ifTrue: [
		ll _ PopUpMenu withCaption: 'The language for word definitions and spelling verification:'
			chooseFrom: Languages.
		ll > 0 ifTrue: [
			^ Preferences setPreference: #myLanguage toValue: (Languages at: ll) asSymbol]].
	ch = 2 ifTrue: [
		ll _ PopUpMenu withCaption: 'The language to translate from:'
			chooseFrom: CanTranslateFrom.
		ll > 0 ifTrue: [
			^ Preferences setPreference: #languageTranslateFrom 
				toValue: (CanTranslateFrom at: ll) asSymbol]].
	ch = 3 ifTrue: [
		ll _ PopUpMenu withCaption: 'The language to translate to'
			chooseFrom: CanTranslateFrom.
		ll > 0 ifTrue: [
			^ Preferences setPreference: #languageTranslateTo 
				toValue: (CanTranslateFrom at: ll) asSymbol]].

"Maybe let the user add another language when he knows ther server can take it."
"	ch _ (PopUpMenu labelArray: Languages, {'other...'.
			'Choose language to translate from...'})
		startUpWithCaption: 'Choose the language of dictionary for word definitions.'.
	ch = 0 ifTrue: [^ Preferences valueOfFlag: #myLanguage].
	(ch <= Languages size) ifTrue: [ll _ Languages at: ch].
	ch = (Languages size + 1) ifTrue: [
		ll _ FillInTheBlank request: 'Name of the primary language'].
	ll ifNotNil: [^ Preferences setPreference: #myLanguage toValue: ll asSymbol].
"