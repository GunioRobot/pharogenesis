buildPluggablePanel: aSpec
	"Build a pluggable panel (aka button row!)."
	
	| widget children |
	widget := PluggableThemedPanelMorph new.
	self register: widget id: aSpec name.
	widget model: aSpec model.
	widget fillStyle: widget normalFillStyle.
	widget clipSubmorphs: true.
	children := aSpec children.
	children isSymbol ifTrue:[
		widget getChildrenSelector: children.
		widget update: children.
		children := #().
	].
	self buildAll: children in: widget.
	self setFrame: aSpec frame in: widget.
	parent ifNotNil:[self add: widget to: parent].
	self setLayout: aSpec layout in: widget.
	^widget