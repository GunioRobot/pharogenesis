getMultilineResponse
	"Get a multiple line response to the last command, filtering out LF characters. A multiple line response ends with a line containing only a single period (.) character."

	| response done chunk |
	response _ WriteStream on: ''.
	done _ false.
	[done] whileFalse: [
		chunk _ self stream nextLine.
		(chunk beginsWith: '.')
			ifTrue: [response nextPutAll: (chunk copyFrom: 2 to: chunk size); cr ]
			ifFalse: [response nextPutAll: chunk; cr ].
		done _ (chunk = '.') ].

	^ response contents
