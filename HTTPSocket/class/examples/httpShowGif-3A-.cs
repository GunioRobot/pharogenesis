httpShowGif: url
	"Display the picture retrieved from the given URL, which is assumed to be a GIF file. See examples in httpGif:."

	| nameTokens |
	nameTokens _ url findTokens: '/'.
	FormView open: (self httpGif: url) named: nameTokens last.
