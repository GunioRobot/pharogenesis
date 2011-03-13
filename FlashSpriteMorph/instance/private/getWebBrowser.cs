getWebBrowser
	"Return a web browser if we're running in one"

	self withAllOwnersDo:
		[:morph | morph isWebBrowser ifTrue: [^ morph].
		(morph hasProperty: #webBrowserView) ifTrue: [^ morph model]].
	^ nil