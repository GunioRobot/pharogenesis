browse: pageRef from: request
	"Just reply with a page in HTML format"

	| formattedPage liveText|
	liveText _ HTMLformatter evalEmbedded: (pageRef text)
		with: request unlessContains: (self dangerSet).
	formattedPage _ pageRef copy.
	"Make a copy, then format the text."
	formattedPage formatted: (formatter swikify: liveText
			linkhandler: [:link | urlmap
					linkFor: link
					from: request peerName
					storingTo: OrderedCollection new
					page: formattedPage]).
	request reply: ((self formatterFor: 'page') format: formattedPage).
