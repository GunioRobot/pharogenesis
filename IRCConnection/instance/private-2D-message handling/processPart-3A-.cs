processPart: aMessage
	"a user is leaving a channel"
	| channelName user |
	channelName _ aMessage arguments first.
	user _ aMessage prefix.
	(user includes: $!) ifTrue: [ user _ user copyFrom: 1 to: (user indexOf: $!)-1 ].

	(self channelInfo: channelName) removeMember: user