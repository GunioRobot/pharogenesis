strings
	| strm |
	"Get started making a vocabulary for a foreign language.  That is, build a method like #addGermanVocabulary, but for another language.  
	Returns this vocabulary in the same form used as the input used for foreign languages.  To avoid string quote problems, execute
	Transcript show: Vocabulary eToyVocabulary strings.
and copy the text from the transcript to the method you are building."

	"selector		wording			documentation"

strm _ WriteStream on: (String new: 400).
methodInterfaces keys asSortedCollection do: [:sel |
	strm cr; nextPut: $(;
		nextPutAll: sel; tab; tab; tab; nextPut: $';
		nextPutAll: (methodInterfaces at: sel) wording;
		nextPut: $'; tab; tab; tab; nextPut: $';
		nextPutAll: (methodInterfaces at: sel) documentation;
		nextPut: $'; nextPut: $)].
^ strm contents