inputFrom: request
	"Take user's input and respond with a searchresult or store the edit"

	| coreRef page theText |
	coreRef _ request message size < 2
		ifTrue: ['1']
		ifFalse: [request message at: 2].
	coreRef = 'searchresult' ifTrue: [
		"If contains search string, do search"
		request reply: PWS crlf,
			(HTMLformatter evalEmbedded: (self fileContents: source, 'results.html')
				with: (urlmap searchFor: (
					request fields at: 'searchFor' ifAbsent: ['nothing']))).
		^ #return].
	(theText _ request fields at: 'text' ifAbsent: [nil]) ifNotNil: [
		"It's a response from an edit, so store the page"
		page _ urlmap atID: coreRef.
		page user: request peerName.  "Address is machine, user only if logged in"
		 page pageStatus = #new ifTrue: [page pageStatus: #standard].
		page _ urlmap
			storeID: coreRef
			text: theText withSqueakLineEndings
			from: request peerName.
		self generate: (urlmap atID: coreRef) from: request.
		self generateRecent.

		^ self].	"return self means do serve the edited page afterwards"
	request fields keys do: [:aTag |
		(aTag beginsWith: 'text-') ifTrue: [
			urlmap
				storeID: coreRef
				text: (request fields at: aTag) withSqueakLineEndings
				insertAt: (aTag copyFrom: 6 to: aTag size).
	"string"
		self generate: (urlmap atID: coreRef) from: request.
		self generateRecent.
			^ self]].		"oops, a new kind!"
	Transcript show: 'Unknown data from client. '; show: request fields
printString; cr.