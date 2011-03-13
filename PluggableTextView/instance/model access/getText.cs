getText 
	"Answer the list to be displayed."
	| txt |
	getTextSelector == nil ifTrue: [^ Text new].
	txt := model perform: getTextSelector.
	txt == nil ifTrue: [^ Text new].
	self hasUnacceptedEdits: false.	"clean now"
	^ txt