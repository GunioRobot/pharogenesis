copyName
	"Copy the current selector to the clipboard"
	| selector |
	(selector _ self selectedMessageName) ifNotNil:
		[ParagraphEditor clipboardTextPut: selector asString asText]