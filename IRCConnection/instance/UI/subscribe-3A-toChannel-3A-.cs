subscribe: anObject toChannel: channelName
	"send all messages for channelName to anObject.  anObject must implemented #ircMessageReceieved:"

	|  info |

	info _ self channelInfo: channelName.

	info subscribe: anObject.