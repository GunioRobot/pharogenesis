setValue: newValue
	"Update the target with this sliders new value."

	| scaledValue |
	self value: newValue.
	scaledValue _ (newValue * (maxVal - minVal)) + minVal.
	truncate ifTrue: [scaledValue _ scaledValue truncated].
	(target ~~ nil and: [setValueSelector ~~ nil]) ifTrue: [
		Cursor normal showWhile: [
			target
				perform: setValueSelector
				withArguments: (arguments copyWith: scaledValue)]].
