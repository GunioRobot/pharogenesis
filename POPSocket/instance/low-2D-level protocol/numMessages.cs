numMessages
	"Query the server and answer the number of messages that are in the user's mailbox."

	| response answerString |
	numMessages ifNotNil: [^ numMessages].  "cached result of earlier query"

	self sendCommand: 'STAT'.
	response _ self getResponse.
	self reportToObservers: response.
	(response beginsWith: '+OK') ifFalse: [^ 0].  "error"
	answerString _ (response findTokens: Character separators) second.

	"NB: It is important to cache the result so that all operations, especially delete and deleteAll, are done on the same set of messages"
	numMessages _ answerString asNumber asInteger.	"cache the result"

	^ numMessages