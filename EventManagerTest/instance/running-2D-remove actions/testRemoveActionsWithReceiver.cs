testRemoveActionsWithReceiver

	| action |
	eventSource
		when: #anEvent send: #size to: eventListener;
		when: #anEvent send: #getTrue to: self;
		when: #anEvent: send: #fizzbin to: self.
	eventSource removeActionsWithReceiver: self.
	action := eventSource actionForEvent: #anEvent.
	self assert: (action respondsTo: #receiver).
	self assert: ((action receiver == self) not)