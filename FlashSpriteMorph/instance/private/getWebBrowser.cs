getWebBrowser
	"Return a web browser if we're running in one"
	| morph |
	morph _ self. "I can't really be a web browser, can I?!"
	[morph isNil] whileFalse:[
		morph isWebBrowser ifTrue:[^morph].
		(morph hasProperty: #webBrowserView) ifTrue:[^morph model].
		morph _ morph owner].
	"Not in a browser"
	^nil