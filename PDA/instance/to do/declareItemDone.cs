declareItemDone
	| report |
	report _ FillInTheBlank request:
'This item will be declared done as of
' , date printString , '.
Please give a short summary of status'
		initialAnswer: 'Completed.'.
	(report == nil or: [report isEmpty]) ifTrue: [^ self].
	currentItem dayDone: date;
			result: report.
	self currentItem: currentItem