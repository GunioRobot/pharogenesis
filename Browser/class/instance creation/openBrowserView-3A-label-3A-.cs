openBrowserView: aBrowserView label: aString 
	"Schedule aBrowserView, labelling the view aString."

	(aBrowserView setLabel: aString) openInWorld.
	^ aBrowserView model
