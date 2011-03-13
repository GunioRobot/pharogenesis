createAcceptButton
	"create the [accept] button"
	| result frame |
	result := SimpleButtonMorph new target: self;
				 color: ColorTheme current okColor.
	result
		borderColor: (Preferences menuAppearance3d
				ifTrue: [#raised]
				ifFalse: [result color twiceDarker]).
	result label: 'Accept(s)' translated;
		 actionSelector: #accept.
	result setNameTo: 'accept'.
	frame := LayoutFrame new.
	frame rightFraction: 0.5;
		 rightOffset: -10;
		 bottomFraction: 1.0;
		 bottomOffset: -2.
	result layoutFrame: frame.
	self addMorph: result.
	self
		updateColor: result
		color: result color
		intensity: 2.
	^ result