inputFrom: request
	"Take user's input and respond with a searchresult or store the edit"
"	{swikiname}.{coreID}  {with a field named 'text'}  store an edited page
	{swikiname}.{coreID}  {with a field named 'text-placeID'}  store text
in a specific place
	{swikiname}.searchresult  {with a field named 'searchFor'} conducts the
search for that text and sends back the result
"
	| coreRef page theText |
	coreRef _ request message size < 2
		ifTrue: ['1']
		ifFalse: [request message at: 2].
	coreRef = 'searchresult' ifTrue: [
		"If contains search string, do search"
		request reply: PWS crlf,
			((self formatterFor: 'recent') format: (urlmap
searchFor:
						(request fields at:
'searchFor' ifAbsent:
['nothing']))).
		^ #return].
	(theText _ request fields at: 'text' ifAbsent: [nil]) ifNotNil: [
		"It's a response from an edit, so store the page"
		page _ urlmap atID: coreRef.
		page user: request peerName.  "Address is machine, user only if
logged in"
		 page pageStatus = #new ifTrue: [page pageStatus: #standard].
		page _ urlmap
			storeID: coreRef
			text: theText withSqueakLineEndings
			from: request peerName.
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