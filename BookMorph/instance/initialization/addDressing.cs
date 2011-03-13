addDressing
	| controlColor pageControls |
	self addMorph: (Morph new color: color; extent: 10@10).  "spacer"
	controlColor _ (color saturation > 0.1)
		ifTrue:
			[color lighter]
		ifFalse:
			[color darker].
	pageControls _ Preferences noviceMode
		ifTrue:
			[self makeKidsPageControlsColored: controlColor]
		ifFalse:
			[self makeAuthoringPageControlsColored: controlColor].
	pageControls borderWidth: 1; inset: 4.
			
	self addMorph: pageControls