mouseUpBrowserAndUrl: browserAndUrl event: event linkMorph: linkMorph
	"this is an image map area, just follow the link"
	| browser url |
	browser _ browserAndUrl first.
	url _ browserAndUrl second.
	browser jumpToUrl: url