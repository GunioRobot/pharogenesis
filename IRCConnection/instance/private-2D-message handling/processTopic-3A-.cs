processTopic: aMessage
	"change a channel topic"
	| args |
	args _ aMessage arguments.
	args size < 2 ifTrue: [ "malformed message" ^self ].
	(self channelInfo: (args at: (args size-1))) topic: (args at: args size).