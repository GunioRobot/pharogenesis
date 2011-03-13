runBlock
	| stream list result |
	tally := MessageTally new.
	result _ tally spyEvery: 16 on: block.
	stream := ReadWriteStream with: (String streamContents: [:s | tally report: s; close]).
	stream reset.
	list := OrderedCollection new.
	[stream atEnd] whileFalse: [list add: stream nextLine].
	self initializeMessageList: list.
	self changed: #messageList.
	self changed: #messageListIndex.
	^ result
