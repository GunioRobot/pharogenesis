addMember: memberName
	"note that memberName is on the channel.  memberName should be given in the user's preferred capitalization"
	members add: memberName.
	self changed: #memberNames.