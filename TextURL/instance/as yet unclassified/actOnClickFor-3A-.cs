actOnClickFor: anObject
	"Do what you can with this URL.  Later a web browser."

	| response m |

	"if it's a web browser, tell it to jump"
	anObject isWebBrowser
		ifTrue: [anObject jumpToUrl: url. ^ true]
		ifFalse: [((anObject respondsTo: #model) and: [anObject model isWebBrowser])
				ifTrue: [anObject model jumpToUrl: url. ^ true]].

		"if it's a morph, see if it is contained in a web browser"
		(anObject isKindOf: Morph) ifTrue: [
			m _ anObject.
			[ m ~= nil ] whileTrue: [
				(m isWebBrowser) ifTrue: [
					m  jumpToUrl: url.
					^true ].
				(m hasProperty: #webBrowserView) ifTrue: [
					m model jumpToUrl: url.
					^true ].
				m _ m owner. ]
		].

	"no browser in sight.  ask if we should start a new browser"
	(self confirm: 'open a browser to view this URL?') ifTrue: [
		Scamper openOnUrl: url.
		^ true ].

	"couldn't display in a browser.  Offer to put up just the source"

	response _ (PopUpMenu labels: 'View web page as source\Cancel' withCRs)
		startUpWithCaption: 'Couldn''t find a web browser.  View
page as source?'.
	response = 1 ifTrue: [HTTPSocket httpShowPage: url].
	^ true