example
	"POPSocket example"
	"download a user's messages into an OrderedCollection and inspect the OrderedCollection"

	| ps messages |
	ps _ POPSocket new.
	ps serverName: (FillInTheBlank request: 'POP server').
	ps userName: (FillInTheBlank request: 'POP username').
	ps password: (FillInTheBlank request: 'POP password').
	ps addProgressObserver: Transcript.

	messages _ OrderedCollection new.
	ps connectToPOP.
	ps messagesDo: [ :messageText |
		messages add: messageText ].
	ps disconnectFromPOP.

	messages inspect.