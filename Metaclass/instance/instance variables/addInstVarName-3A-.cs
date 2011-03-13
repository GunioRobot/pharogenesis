addInstVarName: aString 
	"Add the argument, aString, as one of the receiver's instance variables."

	| fullString |
	fullString := aString.
	self instVarNames do: [:aString2 | fullString := aString2 , ' ' , fullString].
	self instanceVariableNames: fullString