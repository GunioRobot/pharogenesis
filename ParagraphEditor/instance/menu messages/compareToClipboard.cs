compareToClipboard
	"Check to see if whether the receiver's text is the same as the text currently on the clipboard, and inform the user."
	| s1 s2 |
	s1 _ self clipboardText string.
	s2 _ paragraph text string.
	s1 = s2 ifTrue: [^ self inform: 'Exact match'].

	(StringHolder new textContents:
		(TextDiffBuilder buildDisplayPatchFrom: s1 to: s2))
		openLabel: 'Comparison to Clipboard Text'