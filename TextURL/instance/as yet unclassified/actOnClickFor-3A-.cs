actOnClickFor: anObject
	"Do what you can with this URL.  Later a web browser."

	| response |
	(url asLowercase endsWith: '.gif') ifTrue: [
		HTTPSocket httpShowGif: url].	"opens a new window"
	response _ (PopUpMenu labels: 'View web page as source\Cancel' withCRs)
		startUpWithCaption: 'Sorry, we don''t have a web browser yet'.
	response = 1 ifTrue: [HTTPSocket httpShowPage: url].
	^ true