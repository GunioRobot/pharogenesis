messageCount
	"Query the server and answer the number of messages that are in the user's mailbox."

	| answerString numMessages |
	self ensureConnection.
	self sendCommand: 'STAT'.
	self checkResponse.
	self logProgress: self lastResponse.

	[answerString := (self lastResponse findTokens: Character separators) second.
	numMessages := answerString asNumber asInteger]
		on: Error
		do: [:ex | (ProtocolClientError protocolInstance: self) signal: 'Invalid STAT response.'].
	^numMessages