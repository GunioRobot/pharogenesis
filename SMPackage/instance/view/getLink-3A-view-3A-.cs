getLink: aBuilder view: aView
	"Return a link for using on the web."

	^aBuilder getLink: 'package/', id asString text: name view: aView