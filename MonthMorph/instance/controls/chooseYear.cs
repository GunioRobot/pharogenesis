chooseYear

	| newYear yearString |
	newYear _ (SelectionMenu selections:
					{'today'} , (month year - 5 to: month year + 5) , {'other...'})
						startUpWithCaption: 'Choose another year'.
	newYear ifNil: [^ self].
	newYear isNumber ifTrue:
		[^ self month: (Month month: month monthName year: newYear)].
	newYear = 'today' ifTrue:
		[^ self month: (Month starting: Date today)].
	yearString _ FillInTheBlank 
					request: 'Type in a year' initialAnswer: Date today year asString.
	yearString ifNil: [^ self].
	newYear _ yearString asNumber.
	(newYear between: 0 and: 9999) ifTrue:
		[^ self month: (Month month: month monthName year: newYear)].
