allUnSentMessages
	"Answer an Array of each message that is implemented by some object in  the system but is not sent by any.
	 5/8/96 sw: call factored-out method allUnSentMessagesIn:"

	| anArray sels |
	anArray _ Array new.
	sels _ self allUnSentMessagesIn: self allImplementedMessages.
	sels do: [:sel | anArray _ anArray , (self allImplementorsOf: sel)].
	^ anArray