browse: pageRef from: request
	"Just reply with a page in HTML format"

	| formattedPage |
	formattedPage _ pageRef copy.

	"Make a copy, then format the text."
	formattedPage formatted: (HTMLformatter swikify: pageRef text
			linkhandler: [:link | urlmap
					linkFor: link
					from: request peerName
					storingTo: OrderedCollection new]).
		
	"format using the cached formatter"
	request reply: ((self formatterFor: 'page') format: formattedPage). 
