contentsFromTarget
	"private - answer the contents from the receiver's target"
	| contentsAsText |
	contentsAsText := super contentsFromTarget asText.
	contentsAsText
		addAttribute: (TextFontReference toFont: self font).
	^ contentsAsText