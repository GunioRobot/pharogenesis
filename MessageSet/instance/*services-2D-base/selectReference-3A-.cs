selectReference: ref
	self okToChange ifTrue: [self messageListIndex: (self messageList indexOf: ref)]