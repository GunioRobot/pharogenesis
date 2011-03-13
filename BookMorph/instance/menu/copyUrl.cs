copyUrl
	"Copy this page's url to the clipboard"
	| str |
	str _ currentPage url ifNil: [str _ 'Page does not have a url.  Send page to server first.'].
	Clipboard clipboardText: str asText.
