browse: pageRef from: request
	"Just reply with a page in HTML format"

	| formattedPage htmlForUser |
	formattedPage _ pageRef copy.

	"Make a copy, then format the text."
	formattedPage formatted: (formatter swikify: pageRef text
			linkhandler: [:link | urlmap
					linkFor: link
					from: request peerName
					storingTo: OrderedCollection new
					page: formattedPage]).

	"format using the cached formatter"
	htmlForUser _ ((self formatterFor: 'page') format: formattedPage).
	htmlForUser size = 0 ifTrue: [self error: 'template file
''page.html'' not found'].
	request reply: htmlForUser.
