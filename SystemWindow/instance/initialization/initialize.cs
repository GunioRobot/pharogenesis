initialize
	super initialize.
	borderColor _ #raised.
	borderWidth _ 2.
	color _ Color r: 0.6 g: 0.2 b: 0.2.
	paneColor _ Color r: 0.8 g: 1.0 b: 0.599.
	self addMorph: (label _ StringMorph new contents: labelString;
						font: ((TextStyle default fontAt: 2) emphasized: 1)).
	self addMorph: (closeBox _ SimpleButtonMorph new borderWidth: 2; color: paneColor;
							label: 'X'; actionSelector: #delete; target: self).
	self addMorph: (collapseBox _ SimpleButtonMorph new borderWidth: 2; color: paneColor;
							label: 'O'; actionSelector: #collapse; target: self).
	self initPanes.
	self allMorphsDo: [:m | m paneColor: paneColor].
	self extent: self defaultExtent