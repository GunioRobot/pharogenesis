initialize
	| aFont |
	super initialize.
	allowReframeHandles := true.
	labelString ifNil: [labelString _ 'Untitled Window'].
	isCollapsed _ false.
	activeOnlyOnTop _ true.
	paneMorphs _ Array new.
	paneRects _ Array new.
	borderColor _ #raised.
	borderWidth _ 1.
	color _ Color black.
	aFont _ Preferences standardButtonFont.
	stripes _ Array with: (RectangleMorph newBounds: bounds)  "see extent:"
				with: (RectangleMorph newBounds: bounds).
	self addMorph: (stripes first borderWidth: 1).
	self addMorph: (stripes second borderWidth: 2).
	self addMorph: (label _ StringMorph new contents: labelString;
			font: Preferences windowTitleFont emphasis: 1).
	self setLabelWidgetAllowance.
	self addCloseBox.
	self addMenuControl.
	self addMorph: (collapseBox _ SimpleButtonMorph new borderWidth: 0;
			label: 'O' font: aFont; color: Color transparent;
			actionSelector: #collapseOrExpand; target: self; extent: 14@14).
	Preferences noviceMode ifTrue:
		[closeBox ifNotNil: [closeBox setBalloonText: 'close window'].
		menuBox ifNotNil: [menuBox setBalloonText: 'window menu'].
		collapseBox ifNotNil: [collapseBox setBalloonText: 'collapse/expand window']].
	self on: #mouseEnter send: #spawnReframeHandle: to: self.
	self on: #mouseLeave send: #spawnReframeHandle: to: self.
	label on: #mouseDown send: #relabelEvent: to: self.
	self extent: 300@200.
	mustNotClose _ false.
	updatablePanes _ Array new.