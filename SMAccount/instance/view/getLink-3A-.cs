getLink: aBuilder
	"Return a link for using on the web.
	Always from the top."

	^aBuilder getLinkTop: 'accountbyid/', id asString text: self nameWithInitials