getValidSelectionRule: positionName 
	"Private - Answer the selection position (first, last) in the list of day of 
	the week,  Report an error if positionName is not one of (first, last)."
	| positionSymbol |
	(positionName isMemberOf: String)
		ifFalse: [^ Error signal: 'Position name: "' , positionName , '" is not a String.'].
	positionSymbol := positionName asLowercase asSymbol.
	(#(first last ) includes: positionSymbol)
		ifFalse: [^ Error signal: 'Position name: "' , positionName , '" is not valid.'].
	^ positionSymbol