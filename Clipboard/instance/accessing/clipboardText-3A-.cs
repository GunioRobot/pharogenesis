clipboardText: text 

	| string |
	string _ text asString.
	self noteRecentClipping: text asText.
	contents _ text asText.
	string _ self interpreter toSystemClipboard: string.
	self primitiveClipboardText: string.
