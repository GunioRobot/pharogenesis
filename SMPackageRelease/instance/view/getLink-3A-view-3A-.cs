getLink: aBuilder view: aView
	"Return a link for using on the web."

	^aBuilder getLinkTop: self relativeUrl text: self packageNameWithVersion