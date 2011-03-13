wordDefinition
	| aWord |
	"Look up a single word and open its definition in a separate window.  Use the WordNet server.  Requires internet access.  Default is English, but set it like this
	Preferences setPreference: #naturalLanguage toValue: #Portuguese.
	"

	self lineSelectAndEmptyCheck: [^ self].
	aWord _ self selection asString.
	self terminateAndInitializeAround: [
		WordNet lexiconServer openScamperOn: aWord].


"This code for showing definition in a Workspace
	Cursor execute showWhile: [
		(aDefinition _ WordNet lexiconServer definitionsFor: aWord) ifNil: [
			^ view flash]].

	self terminateAndInitializeAround: [
		(StringHolder new contents: aDefinition) openLabel: aWord
		].
"

