processQuit: aMessage
	"a user has left IRC.  Remove them from all chanels"
	|  user |
	user _ aMessage prefix.
	(user includes: $!) ifTrue: [ user _ user copyFrom: 1 to: (user indexOf: $!)-1 ].

	subscribedChannels do: [ :channel |
		(channel memberNames includes: user) 
			ifTrue: [ channel removeMember: user ] ].