allMatchingIDsIn: aMailDB
	"return a list of all message ID's that match the filter in the specified DB"
	"this is a special case of allMatchingIDsAmong; some subclasses can optimize this significantly"
	^self allMatchingIDsAmong: aMailDB allMessages in: aMailDB