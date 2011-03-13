buildPluggableWindow: aSpec
	| widget children |
	topSize := 0@0 corner: 640@480.
	aSpec layout == #proportional ifFalse:[
		"This needs to be implemented - probably by adding a single pane and then the rest"
		^self error: 'Not implemented'.
	].
	widget := StandardSystemView new.
	self register: widget id: aSpec name.
	widget model: aSpec model.
	children := aSpec children.
	children isSymbol ifTrue:[
		"This isn't implemented by StandardSystemView, so we fake it"
		children := widget model perform: children.
	].
	aSpec extent ifNotNil:[topSize :=  0@0 extent: aSpec extent].
	widget window: topSize.
	panes := OrderedCollection new.
	self buildAll: children in: widget.
	widget setUpdatablePanesFrom: panes.
	^widget