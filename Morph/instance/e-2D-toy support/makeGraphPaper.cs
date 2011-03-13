makeGraphPaper
	| smallGrid backColor lineColor |
	smallGrid := Compiler evaluate: (UIManager default
			request: 'Enter grid size' translated
			initialAnswer: '16').
	smallGrid ifNil: [ ^ self ].
	UIManager default 
		informUser: 'Choose a background color' translated
		during: [ backColor := Color fromUser ].
	UIManager default 
		informUser: 'Choose a line color' translated
		during: [ lineColor := Color fromUser ].
	self 
		makeGraphPaperGrid: smallGrid
		background: backColor
		line: lineColor