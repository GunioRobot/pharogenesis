copyHiddenInfo
	"In TextLinks, TextDoits, TextColor, and TextURLs, there is hidden info.  Copy that to the clipboard.  You can paste it and see what it is.  Usually enclosed in <>."

	| attrList |
	attrList _ paragraph text attributesAt: (startBlock stringIndex + stopBlock stringIndex)//2.
	attrList do: [:attr |
		attr class == TextLink ifTrue: [
			^ self clipboardTextPut: ('<', attr info, '>') asText].
		attr class == TextURL ifTrue: [
			^ self clipboardTextPut: ('<', attr info, '>') asText].
		attr class == TextAction ifTrue: [
			^ self clipboardTextPut: ('<', attr info, '>') asText].
		].
	"If none of the above"
	attrList do: [:attr |
		attr class == TextColor ifTrue: [
			^ self clipboardTextPut: attr color printString asText]].
	^ self clipboardTextPut: '[No hidden info]' asText