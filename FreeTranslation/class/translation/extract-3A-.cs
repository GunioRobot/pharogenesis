extract: aMimeDoc
	| pageSource str |
	"Extract the translated text from the web page"

	(aMimeDoc content beginsWith: 'error') ifTrue: [^ aMimeDoc content].
	pageSource _ aMimeDoc content.
	"brute force way to pull out the result"
	str _ ReadStream on: pageSource.
	str match: 'Translation Results by Transparent Language'.
	str match: '<p>'.
	^ str upToAll: '</p>'