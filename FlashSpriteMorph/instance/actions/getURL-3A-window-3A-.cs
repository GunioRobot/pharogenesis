getURL: urlString window: windowString
	"Load the given url in display it in the window specified by windowString.
	Ignored for now."
	| browser |
	browser := self getWebBrowser.
	browser ifNotNil:[
		browser jumpToUrl: urlString.
		^nil].
	"(self confirm: ('open a browser to view\',urlString,' ?') withCRs) ifTrue: [
		browser := Scamper new.
		browser jumpToUrl: urlString.
		browser openAsMorph
	]."
	^nil