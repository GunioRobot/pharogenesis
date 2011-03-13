< aVersion
	| numToCompare |
	numToCompare := components size min: aVersion components size.
	(components first: numToCompare) with: (aVersion components first: numToCompare) do: [ :myComp :itsComp |
		(myComp uversionLessThan: itsComp) ifTrue: [
			^true ].
		(itsComp uversionLessThan: myComp) ifTrue: [
			^false ] ].
	
	^components size < aVersion components size