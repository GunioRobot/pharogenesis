newContents: stringOrText
	"Accept new text contents."
	| newText |
	newText _ stringOrText asText.
	text = newText ifTrue: [^ self].  "No substantive change"
	text _ newText.
	self releaseParagraph.  "update the paragraph cache"
	self paragraph.  "re-instantiate to set bounds"