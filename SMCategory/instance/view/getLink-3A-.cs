getLink: aView
	"Return a link for using on the web."

	^aView linklocal: '/category/', id asString text: name