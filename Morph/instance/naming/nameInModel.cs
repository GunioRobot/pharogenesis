nameInModel
	"Return the name for this morph in the underlying model or nil."

	| w |
	w _ self world.
	w == nil
		ifTrue: [^ nil]
		ifFalse: [^ w model nameFor: self].
