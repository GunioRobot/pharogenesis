verifyWordSpelling
	| aWord answer |
	"Look up a single word and inform the user if it was found.  Use the WordNet server.  Requires internet access.  Default is English, but set it like this
	Preferences setPreference: #naturalLanguage toValue: #Deutsch.
	"

	self lineSelectAndEmptyCheck: [^ self].
	aWord _ self selection asString.

	Cursor execute showWhile: [
		answer _ WordNet lexiconServer verify: aWord].

	self terminateAndInitializeAround: [
		self inform: answer].

