currentItemMenu: aMenu
	| donorMenu labels |
	viewDescriptionOnly
		ifTrue: [aMenu add: 'view entire records' target: self selector: #toggleDescriptionMode]
		ifFalse: [aMenu add: 'view descriptions only' target: self selector: #toggleDescriptionMode].
	aMenu addLine.
	aMenu add: 'save database' target: self selector: #saveDatabase.
	aMenu add: 'load database from file...' target: self selector: #loadDatabase.
	aMenu add: 'spawn entire month' target: self selector: #openMonthView.
	aMenu addLine.
	aMenu add: 'accept (s)' target: self selector: #accept.
	aMenu add: 'cancel (l)' target: self selector: #cancel.
	aMenu addLine.
	donorMenu _ ParagraphEditor yellowButtonMenu.
	labels _ donorMenu labelString findTokens: String cr.
	aMenu labels: (labels allButLast: 4) lines: donorMenu lineArray selections: donorMenu selections.
	^ aMenu