lexiconServer
	"Look in Preferences to see what language the user wants, and what class knows about it."

	| nl |
	nl _ Preferences parameterAt: #myLanguage ifAbsentPut: [#English].
	nl == #English ifTrue: [^ self].		"English, WordNet server"
	nl == #Portuguese ifTrue: [^ PortugueseLexiconServer].	"www.priberam.pt"

"	nl == #Deutsch ifTrue: [^ DeutschServerClass]. "	"class that knows about a server"

	self inform: 'Sorry, no known online dictionary in that language.'.
	^ self languagePrefs