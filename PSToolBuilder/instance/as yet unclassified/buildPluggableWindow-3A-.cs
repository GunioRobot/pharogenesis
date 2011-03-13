buildPluggableWindow: aSpec
	| widget children label |
	aSpec layout == #proportional ifFalse:[
		"This needs to be implemented - probably by adding a single pane and then the rest"
		^self error: 'Not implemented'.
	].
	widget := PluggableStandardWindow new.
	self register: widget id: aSpec name.
	widget model: aSpec model.
	(label := aSpec label) ifNotNil:[
		label isSymbol 
			ifTrue:[widget getLabelSelector: label]
			ifFalse:[widget setLabel: label]].
	children := aSpec children.
	children isSymbol ifTrue:[
		widget getChildrenSelector: children.
		widget update: children.
		children := #().
	].
	widget closeWindowSelector: aSpec closeAction.
	panes := OrderedCollection new.
	self buildAll: children in: widget.
	aSpec extent ifNotNil:[widget extent: aSpec extent].
	widget setUpdatablePanesFrom: panes.
	^widget