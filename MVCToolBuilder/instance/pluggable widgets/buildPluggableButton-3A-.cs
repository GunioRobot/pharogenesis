buildPluggableButton: aSpec
	| widget label state |
	label := aSpec label.
	state := aSpec state.
	widget := PluggableButtonView on: aSpec model
				getState: (state isSymbol ifTrue:[state])
				action: aSpec action
				label: (label isSymbol ifTrue:[label]).
	self register: widget id: aSpec name.
	(label isSymbol or:[label == nil]) ifFalse:[widget label: label].
	self setFrame: aSpec frame in: widget.
	parent ifNotNil:[parent addSubView: widget].
	^widget