newDayOfWeek: dayName selectionRule: positionName 
	"Private - Answer an uncreated rule date with the dayOfWeek (Sunday, 
	etc) set to dayName, and selectionRule (first, last) set to positionName. 
	Note: Must be updated to create the date. 
	 
	Parameters 
	dayName		<readableString>		captured 
	positionName	<readableString>		captured 
	Return Values 
	<RuleDate>		new
	"
	| daySymbol newRuleDate positionSymbol |
	(dayName isMemberOf: String)
		ifFalse: [^ Error signal: 'Day name: "' , dayName , '" is not a String.'].
	daySymbol := dayName asLowercase.
	daySymbol at: 1 put: (daySymbol at: 1) asUppercase.
	daySymbol := daySymbol asSymbol.
	(Week dayNames includes: daySymbol)
		ifFalse: [^ Error signal: 'Day name: "' , dayName , '" is not valid.'].
	positionSymbol := self getValidSelectionRule: positionName.
	newRuleDate := super new.
	newRuleDate setDayOfWeek: daySymbol selectionRule: positionSymbol.
	^ newRuleDate