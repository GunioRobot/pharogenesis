indexed: dayName inMonth: monthIn year: yearIn at: dayListIndex 
	"Answer a date that is at the dayListIndex position of the list of day of 
	the week (Sunday, etc), dayName, in month, monthIn, of year, yearIn.  
	Example:  
	RuleIndexDate indexed: 'Sunday' inMonth: 'April' year: 2000 at: 2. 
	 
	Note: The month may be an index or a month name. 
	The year may be specified as the actual number of years since the 
	beginning of the Roman calendar or the  number of years since 1900, 
	or a two digit date from 1900.  1/1/01 will NOT mean 2001. 
	 
	Definition: <RuleDate factory> 
	Parameters 
	dayName		<readableString>				captured 
	monthIn		<readableString> | <Integer>	captured 
	yearIn			<Integer>					captured 
	dayListIndex		<Integer>					captured 
	Return Values 
	<RuleDate>		new 
	Errors 
	Day name is not a String and a valid day of the week 
	Month is not an Integer 1 - 12. or a valid month name String
	"
	| mmInt newRuleDate |
	mmInt := self getValidMonthNumber: monthIn.
	newRuleDate := self newDayOfWeek: dayName selectionRule: dayListIndex.
	newRuleDate basicUpdateForMonth: mmInt year: yearIn.
	^ newRuleDate