getLink: aBuilder
	"Return a link for using on the web."

	^aBuilder getLinkLocal: '/package/', id asString text: name