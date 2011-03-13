receivedMessagesDo: aBlock
	"check for new messages, and then evaluate aBlock for each message that is currently available"
	self processIO.
	[ inMessages isEmpty ] whileFalse: [
		aBlock value: inMessages removeFirst ]