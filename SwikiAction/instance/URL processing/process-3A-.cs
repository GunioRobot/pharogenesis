process: request
	"URLs are of the form:
	{swikiname} 		browse Front Page
	{swikiname}.{coreID} browse the page number coreID
	{swikiname}.{coreID}.edit  request to edit the page
	{swikiname}.{coreID}.versions show the last three versions of the page
	{swikiname}.{coreID}  {with a field named 'text'}  store an edited page
	{swikiname}.{coreID}.insert.{placeID}  request to insert text in a
specific place in a page
	{swikiname}.{coreID}  {with a field named 'text-placeID'}  store
text in a specific place
	-------
	{swikiname}.{coreID}.all  displays the page and all its references
	{swikiname}.searchresult  conducts the search and displays the result
	{swikiname}.recent  to bring up the recent changes list
	{swikiname}.{coreID}.searchresult  returns a search for references
to coreID's key
	{swikiname}.{picName}.gif   or .jpeg, .jpg, .jpe, .html (upper or
lower case) return
	the picture or static page stored in the {swikiname} folder."

	| coreRef pageRef command formattedPage theLast pvtPageRef htmlForUser |
	self log: request.
	theLast _ request message last asLowercase.
	theLast = 'gif' ifTrue: [^ self process: request MIMEtype: 'image/gif'].
	theLast = 'jpeg' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
	theLast = 'jpg' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
	theLast = 'jpe' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
	theLast = 'html' ifTrue: [^ self process: request MIMEtype: 'text/html'].
	request reply: PWS success;
		reply: PWS contentHTML.
	Transcript show: 'In process: ' , request message printString; cr.
	request message size < 2
		ifTrue: [coreRef _ '1']
		ifFalse: [coreRef _ request message at: 2].
	request fields ifNotNil: ["Are there input fields?"
			(self inputFrom: request) == #return ifTrue: [^ self]].
	coreRef = 'recent' ifTrue:
			[request reply: PWS crlf , ((self formatterFor: 'recent')
						format: urlmap recent).
			^ self].
	request reply: PWS crlf.
	"End of header.  Move this when we want to report more header"
	"At this point, coreRef is a page reference"
	pageRef _ urlmap atID: coreRef.
	request message size > 2 ifTrue:
			["SearchResult, All, Versions, or Edit"
			command _ request message at: 3.
			command = 'edit' ifTrue:
					[request reply: ((self formatterFor: 'edit') format: pageRef).
					pageRef noteEditRequest.
					^ self].
			command = 'versions' ifTrue:
					[request reply: ((self formatterFor: 'versions') format: pageRef).
					^self].
			command = 'insert' ifTrue:
					[pvtPageRef _ pageRef clone.
					pvtPageRef placeID: (request message at: 4).	"so <?request placeID?> can get it"
					htmlForUser _ ((self formatterFor: 'insert') format: pvtPageRef).
					htmlForUser size = 0 ifTrue: [
						self error: 'template file ''insert.html'' not found'].
					request reply: htmlForUser.
					pageRef noteEditRequest.
					^ self].
			command = 'searchresult' ifTrue:
					[request reply: ((self formatterFor: 'results')
						format: (urlmap searchFor: pageRef name)).
					^ self].
			command = 'all' ifTrue:
					[formattedPage _ urlmap allPagesFrom: pageRef for: request.
					request reply: ((self formatterFor: 'page') format: formattedPage).
					^ self].
			(request message at: 1) = (request message at: 2) ifTrue: [
				request reply: '<h1>Your original url has a slash after it.  Please remove it.</h1>'.
				request message: (request message copyFrom: 2 to: request message size).
				^ self process: request].	"(success and contentHTML will be sent twice!)"
			Transcript show: 'Unknown command: ' , command; cr.
			^ self].
	"Just a browse"
	^ self browse: pageRef from: request