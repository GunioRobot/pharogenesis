initialize
	| aFont |
	super initialize.
	isCollapsed _ false.
	activeOnlyOnTop _ true.
	paneMorphs _ Array new.
	paneRects _ Array new.
	borderColor _ #raised.
	borderWidth _ 1.
	color _ Color black.
	aFont _ Preferences fontForScriptorButtons.
	stripes _ Array with: (RectangleMorph newBounds: bounds)  "see extent:"
				with: (RectangleMorph newBounds: bounds).
	self addMorph: (stripes first borderWidth: 1).
	self addMorph: (stripes second borderWidth: 2).
	self addMorph: (label _ StringMorph new contents: labelString;
			font: ((TextStyle default fontAt: 2) emphasized: 1)).
	self addMorph: (closeBox _ SimpleButtonMorph new borderWidth: 0;
			label: 'X' font: aFont; color: Color transparent;
			actionSelector: #delete; target: self; extent: 16@16).
	self addMorph: (collapseBox _ SimpleButtonMorph new borderWidth: 0;
			label: 'O' font: aFont; color: Color transparent;
			actionSelector: #collapseOrExpand; target: self; extent: 16@16).
	self extent: 300@200