textSearch
	"search the text on all pages of this book"

	| wanted wants list str |
	list _ self valueOfProperty: #searchKey ifAbsent: [#()].
	str _ String streamContents: [:strm | 
			list do: [:each | strm nextPutAll: each; space]].
	wanted _ FillInTheBlank request: 'words to search for.  Order is not important.
Beginnings of words are OK.'
		initialAnswer: str.
	wants _ wanted findTokens: Character separators.
	wants size = 0 ifTrue: [^ self].
	self getAllText.		"save in allText, allTextUrls"
	^ self findText: wants	"goes to the page and highlights the text"