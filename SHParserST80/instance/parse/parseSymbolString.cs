parseSymbolString
	| first c last |
	first := sourcePosition.
	self nextChar.
	[(c := self currentChar) isNil 
		ifTrue: [
			self rangeType: #unfinishedString start: first end: source size.
			self error	": 'unfinished string'"].
	c ~= $' or: [
		self peekChar = $' 
			ifTrue: [sourcePosition := sourcePosition + 1.true] 
			ifFalse: [false]]
	] whileTrue: [sourcePosition := sourcePosition + 1].
	last := sourcePosition.
	self nextChar.
	self scanPast: #stringSymbol start: first - 1 end: last