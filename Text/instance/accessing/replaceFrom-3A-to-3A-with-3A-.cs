replaceFrom: start to: stop with: aText

	| txt |
	txt _ aText asText.	"might be a string"
	string _ string copyReplaceFrom: start to: stop with: txt string.
	runs _ runs copyReplaceFrom: start to: stop with: txt runs