inputFrom: request
	"Take user's input and respond with a searchresult or store the edit"

	| coreRef page |
	coreRef _ request message size < 2
		ifTrue: ['1']
		ifFalse: [request message at: 2].
	coreRef = 'searchresult' ifTrue: [
		"If contains search string, do search"
		request reply: PWS crlf,
			(HTMLformatter evalEmbedded: (self fileContents:
source, 'results.html')
				with: (urlmap searchFor: (request fields
at: 'searchFor' ifAbsent: ['nothing']))).
		^ #return].
	(request fields includesKey: 'text') ifTrue: [
		"It's a response from an edit, so store the page"
		page _ urlmap atID: coreRef.
		page user: request peerName.  "Address is machine, user only if
logged in"
		 page pageStatus = #new ifTrue: [page pageStatus: #standard].
		page _ urlmap
			storeID: coreRef
			username: (request fields at: 'username' ifAbsent:
[''])
			password: (request fields at: 'password' ifAbsent: [''])
			privs: (request fields at: 'privs' ifAbsent: [''])
			text: (request fields at: 'text' ifAbsent: ['blank
text'])
			from: request peerName.
		page user: request userID.  "Address is machine, user only
if logged in"
		^ self].	"return self means do serve the edited page
afterwards"
	request fields keys do: [:aTag |
		(aTag beginsWith: 'text-') ifTrue: [
			urlmap
				storeID: coreRef
				text: (request fields at: aTag)
withSqueakLineEndings
				insertAt: (aTag copyFrom: 6 to: aTag size).
	"string"
			^ self]].
	"oops, a new kind!"
	Transcript show: 'Unknown data from client. '; show: request fields
printString; cr.
