selected: dayName inMonth: monthIn year: yearIn byCode: selectionBlock 
	"Answer a date selected by selectionBlock given the dayName (Sunday, 
	etc) dayOfMonth list, in month, monthIn, of year, yearIn.  Example: 
	 
	Standard Time starts on Sunday, 
	so the Daylight Time end is the previous day: 
	RuleSelectionCodeDate 
	selected: 'Sunday' 
	inMonth: 'October' 
	year: 2000 
	byCode: [ :sundaysList | 
	(sundaysList last) - 1 
	]. 
	 
	Note: The selected date need not be in the dayOfMonth list, but may be 
	relative to a named day. 
	The month may be an index or a month name. 
	The year may be specified as the actual number of years since the 
	beginning of the Roman calendar or the  number of years since 1900, 
	or a two digit date from 1900.  1/1/01 will NOT mean 2001. 
	Definition: <RuleDate factory> 
	Parameters 
	dayName		<readableString>				captured 
	monthIn		<readableString> | <Integer>	captured 
	yearIn			<Integer>					captured 
	selectionBlock	<monadicValuable>			captured 
	Return Values 
	<RuleDate>		new 
	Errors 
	Day name is not a String and a valid day of the week 
	Month is not an Integer 1 - 12. or a valid month name String
	"
	| mmInt newRuleDate |
	mmInt := self getValidMonthNumber: monthIn.
	newRuleDate := self newDayOfWeek: dayName selectionRule: selectionBlock.
	newRuleDate basicUpdateForMonth: mmInt year: yearIn.
	^ newRuleDate