lastSelection
	"Return the label of the last selected item or nil."

	lastSelection == nil
		ifTrue: [^ lastSelection selector]
		ifFalse: [^ nil].
