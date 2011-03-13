clipboardText: text 

	| string |
	string := text asString.
	self noteRecentClipping: text asText.
	contents := text asText.
	string := self interpreter toSystemClipboard: string.
	self primitiveClipboardText: string.
