removeMember: memberName
	"note that memberName has left (PART-ed or QUIT-ed) the channel"
	members remove: memberName ifAbsent: [ ^self ].
	self changed: #memberNames.