adjustBookControls
	| inner |
	proceedButton ifNil: [^ self].
	proceedButton align: proceedButton topLeft with: (inner := self innerBounds) topLeft + (35@-4).
	debugButton align: debugButton topRight with: inner topRight - (16@4).