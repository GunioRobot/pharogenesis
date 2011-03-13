copyName
	"Copy the current selector to the clipboard"
	| selector |
	(selector _ self selectedMessageName) ifNotNil:
		[Clipboard clipboardText: selector asString asText]