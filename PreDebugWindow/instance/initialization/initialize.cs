initialize
	| aFont proceedLabel debugLabel aWidth |
	super initialize.
	true 
		ifFalse: 
			["Preferences optionalMorphicButtons"

			(aWidth := self widthOfFullLabelText) > 280 ifTrue: [^self].	"No proceed/debug buttons if title too long"
			debugLabel := aWidth > 210 
				ifTrue: 
					["Abbreviated buttons if title pretty long"

					proceedLabel := 'p'.
					'd']
				ifFalse: 
					["Full buttons if title short enough"

					proceedLabel := 'proceed'.
					'debug'].
			aFont := Preferences standardButtonFont.
			self addMorph: (proceedButton := (SimpleButtonMorph new)
								borderWidth: 0;
								label: proceedLabel font: aFont;
								color: Color transparent;
								actionSelector: #proceed;
								target: self).
			proceedButton setBalloonText: 'continue execution'.
			self addMorph: (debugButton := (SimpleButtonMorph new)
								borderWidth: 0;
								label: debugLabel font: aFont;
								color: Color transparent;
								actionSelector: #debug;
								target: self).
			debugButton setBalloonText: 'bring up a debugger'.
			proceedButton submorphs first color: Color blue.
			debugButton submorphs first color: Color red].
	self adjustBookControls