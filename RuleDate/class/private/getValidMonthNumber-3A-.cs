getValidMonthNumber: monthIn 
	"Private - Answer the month number of monthIn if it is a month name 
	String, else monthIn as the month number  if it is an Integer, else 
	signal an error. 
	 
	Definition: <RuleDate factory> 
	Parameters 
	monthIn	<readableString> | <Integer>	captured 
	Return Values 
	<RuleDate>		new 
	Errors 
	Month is not an Integer 1 - 12. or a valid month name String
	"
	monthIn isInteger
		ifTrue: 
			[(monthIn between: 1 and: 12)
				ifTrue: [^ monthIn].
			^ Error signal: 'Month must be 1 - 12.'].
	(monthIn isMemberOf: String)
		ifTrue: [^ self indexOfMonth: monthIn].
	^ Error signal: 'Month must be an Integer 1 - 12 or a month name String.'