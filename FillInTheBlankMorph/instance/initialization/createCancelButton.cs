createCancelButton
	"create the [cancel] button"
	| result frame |
	result := SimpleButtonMorph new target: self;
				 color: ColorTheme current cancelColor.
	result
		borderColor: (Preferences menuAppearance3d
				ifTrue: [#raised]
				ifFalse: [result color twiceDarker]).
	result label: 'Cancel(l)' translated;
		 actionSelector: #cancel.
	result setNameTo: 'cancel'.
	frame := LayoutFrame new.
	frame leftFraction: 0.5;
		 leftOffset: 10;
		 bottomFraction: 1.0;
		 bottomOffset: -2.
	result layoutFrame: frame.
	self addMorph: result.
	self
		updateColor: result
		color: result color
		intensity: 2.
	^ result