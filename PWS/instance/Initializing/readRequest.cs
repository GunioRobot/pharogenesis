readRequest
	"Read the request and return an array of header and query."

	| idx request query length |
	request := ''.
	[	request := request, connection getData.
		(idx := request findString: (self class crlfcrlf)
startingAt: 1) = 0 ] whileTrue.
	header := request copyFrom: 1 to: idx - 1.
	(request beginsWith: 'POST') ifTrue: [
		(length := request asUppercase findString:
'CONTENT-LENGTH:' startingAt: 1) = 0
			ifTrue: [ self error: '* noLength' ].
		length := (request copyFrom: length + 15 to:
		  (request indexOf: Character cr startingAt: length
ifAbsent: []))
			withBlanksTrimmed asNumber + idx + 3.
		[ request size < length ] whileTrue: [ request := request,
connection getData ].
		query := (request copyFrom: idx + 3 to: request size)
withBlanksTrimmed ].
	"Transcript show: request."
	^{ header. query }