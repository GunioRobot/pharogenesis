getLink: aBuilder
	"Return a link for using on the web."

	^aBuilder getLinkLocal: '/accountbyid/', id asString text: self nameWithInitials