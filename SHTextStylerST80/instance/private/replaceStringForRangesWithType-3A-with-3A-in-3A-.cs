replaceStringForRangesWithType: aSymbol with: aString in: aText 
	"Answer aText if no replacements, or a copy of aText with 
	each range with a type of aSymbol replaced by aString"
	| answer toReplace increaseInLength start end |
	
	toReplace := (self rangesIn: aText setWorkspace: false) 
		select: [:each | each type = aSymbol].
	toReplace isEmpty ifTrue: [^aText].
	answer := aText copy.
	increaseInLength := 0.
	(toReplace asSortedCollection: [:a :b | a start <= b start]) 
		do: [:each | 
			start := each start + increaseInLength.
			end := each end + increaseInLength.
			answer 	replaceFrom: start to: end with: aString.
			increaseInLength := increaseInLength + (aString size - each length)].
	^answer