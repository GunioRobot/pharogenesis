process: request
	"URLs are of the form:	
	{swikiname} to browse Front Page	
	{swikiname}.{coreID} to browse the page	
	{swikiname}.{coreID}.edit  to edit the page
	{swikiname}.{coreID}.all  displays the page and all its references
	{swikiname}.searchresult  conducts the search and displays the result
	{swikiname}.recent  to bring up the recent changes list
	{swikiname}.{coreID}.searchresult  returns a search for references to coreID's key
	{swikiname}.{picName}.gif (or jpeg, jpg, jpe, upper or lower case) return the picture stored in the {swikiname} folder."
	"Transcript show: 'Got request ',(request url); cr."

	| coreRef pageRef command formattedPage theLast |
	self log: request.
	theLast _ request message last asLowercase.
	theLast = 'gif' ifTrue: [^ self process: request MIMEtype: 'image/gif'].
	theLast = 'jpeg' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
	theLast = 'jpg' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
	theLast = 'jpe' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
	theLast = 'html' ifTrue: [^ self process: request MIMEtype: 'text/html'].
	request message size < 2
		ifTrue: [coreRef _ '1']
		ifFalse: [coreRef _ request message at: 2].
	request fields ifNotNil: ["Are there input fields?"
		(self inputFrom: request) == #return ifTrue: [^ self]].
	coreRef = 'recent' ifTrue:
			[request reply: PWS crlf, (HTMLformatter 
					evalEmbedded: (self fileContents: source, 'recent.html')
					with: urlmap recent).
			^ self].
"	request reply: PWS crlf.		End of header.  Move this when we want to report more header
"	"At this point, coreRef is a page reference"
	pageRef _ urlmap atID: coreRef.
	request message size > 2 ifTrue: ["SearchResult, All, or Edit"
		command _ request message at: 3.
		command = 'edit' ifTrue:
			[^self edit: pageRef from: request].
		command = 'searchresult' ifTrue:
			[request reply: (HTMLformatter evalEmbedded: 
							(self fileContents: source , 'results.html')
						with: (urlmap searchFor: pageRef name)).
			^ self].
		command = 'all' ifTrue: 
			[formattedPage _ urlmap allPagesFrom: pageRef for: request.
			request reply: (HTMLformatter evalEmbedded: 
							(self fileContents: source, 'page.html')
						with: formattedPage).
			^ self].
		Transcript show: 'Unknown command: ', command; cr.
		^ self].
	"Just a browse"
	^ self browse: pageRef from: request