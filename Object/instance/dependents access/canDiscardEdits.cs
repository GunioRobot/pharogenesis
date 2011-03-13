canDiscardEdits
	"Return true if this model has no dirty panes."

	self dependents do: [:vv |
		vv == self ifFalse: [
			vv canDiscardEdits ifFalse: [^ false]]].
	^ true
