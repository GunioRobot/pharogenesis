open
	"open the receiver on any language"
	" 
	LanguageEditor open. 
	"
	| menu |
	menu := MenuMorph new defaultTarget: self.
	menu addTitle: 'Language Editor for...' translated.
	""
	(NaturalLanguageTranslator availableLanguageLocaleIDs
		asSortedCollection: [:x :y | x asString <= y asString])
		do: [:eachLanguage | ""
			menu
				add: eachLanguage name
				target: self
				selector: #openOn:
				argument: eachLanguage].
	""
	menu popUpInWorld