lastSelection
	"Return the label of the last selected item or nil."

	selectedItem isNil ifTrue: [^selectedItem selector] ifFalse: [^nil]