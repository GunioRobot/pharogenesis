getCoLink: aBuilder view: aView
	"Return a link for using on the web."

	^aBuilder getLink: 'copackage/', id asString text: name view: aView