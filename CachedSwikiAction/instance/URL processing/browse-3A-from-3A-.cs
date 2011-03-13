browse: pageRef from: request
	"Just reply with a page in HTML format"

	| formattedPage |
	formattedPage _ pageRef copy.
	"Make a copy, then format the text."
	formattedPage formatted: (HTMLformatter swikify: pageRef text
			linkhandler: [:link | urlmap
					linkForCache: link
					from: request peerName
					storingTo: OrderedCollection new]).
	request reply: (HTMLformatter evalEmbedded: (self fileContents: source ,'page.html')
			with: formattedPage).
