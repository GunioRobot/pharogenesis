flushAllButDandDEvents
	| newQueue oldQueue  |
	
	newQueue _ SharedQueue new.
	self eventQueue ifNil: 
		[eventQueue := newQueue.
		^self].
	oldQueue _ self eventQueue.
	[oldQueue size > 0] whileTrue: 
		[| item type | 
		item _ oldQueue next.
		type _ item at: 1.
		type = EventTypeDragDropFiles ifTrue: [ newQueue nextPut: item]].
	eventQueue := newQueue.
