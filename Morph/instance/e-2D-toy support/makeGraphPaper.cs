makeGraphPaper
	| smallGrid backColor lineColor |
	smallGrid _ Compiler evaluate: (FillInTheBlank request: 'Enter grid size' initialAnswer: '16').
	smallGrid ifNil: [^ self].
	Utilities informUser: 'Choose a background color' during: [backColor _ Color fromUser].
	Utilities informUser: 'Choose a line color' during: [lineColor _ Color fromUser].
	self makeGraphPaperGrid: smallGrid background: backColor line: lineColor.