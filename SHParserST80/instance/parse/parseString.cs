parseString
	| first c answer last |
	first := sourcePosition.
	answer := ''.
	
	[(c := self currentChar) isNil 
		ifTrue: [
			self rangeType: #unfinishedString start: first - 1 end: source size.
			self error	": 'unfinished string'"].
	(c ~= $' 	
		ifTrue: [answer := answer copyWith: c. true] 
		ifFalse: [false]
	) or: [
		self peekChar = $' 
			ifTrue: [
				sourcePosition := sourcePosition + 1.
				answer := answer copyWith: $'.
				true]
			ifFalse: [false]]
	] whileTrue: [sourcePosition := sourcePosition + 1].
	last := sourcePosition.
	self nextChar.
	self scanPast: #string start: first - 1 end: last.
	^answer