example
	"POP3Client example"
	"download a user's messages into an OrderedCollection and inspect the OrderedCollection"

	| ps messages userName password |
	userName := (FillInTheBlank request: 'POP username').
	password := (FillInTheBlank request: 'POP password').
	ps _ POP3Client openOnHostNamed: (FillInTheBlank request: 'POP server').
	[
	ps loginUser: userName password: password.
	ps logProgressToTranscript.

	messages _ OrderedCollection new.
	1 to: ps messageCount do: [ :messageNr |
		messages add: (ps retrieveMessage: messageNr) ]]
		ensure: [ps close].

	messages inspect.