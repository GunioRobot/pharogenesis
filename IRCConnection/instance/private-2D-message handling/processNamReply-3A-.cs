processNamReply: aMessage
	"list of names for a channel, probably a channel being joined"
	| names lChannelName channelInfo |

	names _ aMessage arguments last findTokens: ' '.
	names _ names collect: [ :origName |
		('+@' includes: origName first) 
			ifTrue: [ origName copyFrom: 2 to: origName size ]
			ifFalse: [ origName ] ].

	lChannelName _ (aMessage arguments at: 3) asIRCLowercase.
	channelInfo _ subscribedChannels at: lChannelName ifAbsent: [nil].
	channelInfo ifNotNil: [ channelInfo addMembers: names ].