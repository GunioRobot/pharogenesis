lastSelection
	"Return the label of the last selected item or nil."

	selectedItem == nil
		ifTrue: [^ selectedItem selector]
		ifFalse: [^ nil].
