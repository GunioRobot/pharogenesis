verify: aWord
	"See if this spelling is in the WordNet lexicon.  Return a string of success, no-such-word, or can't reach the server."

	| aDef nl |
	aDef _ self new.
	(aDef definition: aWord) ifNil:
		[^ 'Sorry, cannot reach that web site.  Task abandoned.
(Make sure you have an internet connection.)'].
	nl _ Preferences parameterAt: #myLanguage ifAbsentPut: [#English].

	(aDef parts) size = 0 
		ifTrue: [^ 'Sorry, ', aWord, ' not found. (', nl, ' lexicon)']
		ifFalse: [^ aWord, ' is spelled correctly.']