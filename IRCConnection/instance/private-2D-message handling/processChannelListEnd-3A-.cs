processChannelListEnd: aMessage
	"a complete channel listing has arrived"

	"end of a channel listing"
	channelList _ channelListBeingBuilt asArray.
	channelListBeingBuilt _ nil.
	self changed: #channelList. 
	self changed: #channelListReport.