processChannelList: aMessage
	"an item has arrived in the list of channels"
	| chanName chanNumUsers chanTopic |

	aMessage arguments size < 4 ifTrue: [ ^self ].

	chanName _ aMessage arguments at: 2.
	chanNumUsers _ (aMessage arguments at: 3) asNumber.
	chanTopic _ (aMessage arguments at: 4).

	chanName = '*' ifTrue: [ ^self ].

	channelListBeingBuilt ifNil: [ channelListBeingBuilt _ OrderedCollection new ].
	channelListBeingBuilt add: (IRCChannelSummary name: chanName numUsers: chanNumUsers topic: chanTopic). 