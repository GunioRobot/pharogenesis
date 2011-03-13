getLink: aBuilder
	"Return a link for using on the web.
	Always from the top."

	^aBuilder getLinkTop: 'category/', id asString text: name