getSelection
	"Answer the model's selection interval."

	getSelectionSelector == nil ifTrue: [^ 1 to: 0].  "null selection"
	^ model perform: getSelectionSelector
