initialize
	| aFont proceedLabel debugLabel aWidth |
	super initialize.
	true "Preferences optionalMorphicButtons" ifFalse:
		[(aWidth _ self widthOfFullLabelText) > 280 ifTrue: [^ self].   "No proceed/debug buttons if title too long"
		aWidth > 210
			ifTrue: "Abbreviated buttons if title pretty long"
				[proceedLabel _ 'p'.
				debugLabel _ 'd']
			ifFalse: "Full buttons if title short enough"
				[proceedLabel _ 'proceed'.
				debugLabel _ 'debug'].
		aFont _  Preferences standardButtonFont.
		self addMorph: (proceedButton _ SimpleButtonMorph new borderWidth: 0;
				label: proceedLabel font: aFont; color: Color transparent;
				actionSelector: #proceed; target: self).
		proceedButton setBalloonText: 'continue execution'.
		self addMorph: (debugButton _ SimpleButtonMorph new borderWidth: 0;
				label: debugLabel font: aFont; color: Color transparent;
				actionSelector: #debug; target: self).
		debugButton setBalloonText: 'bring up a debugger'.

		proceedButton submorphs first color: Color blue.
		debugButton submorphs first color: Color red].

	self adjustBookControls