textSearch: stringWithKeys
	"search the text on all pages of this book"

	| wants |
	wants _ stringWithKeys findTokens: Character separators.
	wants size = 0 ifTrue: [^ self].
	self getAllText.		"save in allText, allTextUrls"
	^ self findText: wants	"goes to the page and highlights the text"