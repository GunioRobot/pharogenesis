groupNames
	"Return the names of all registered groups of servers, including individual servers not in any group.  Note: A serverDirectory that is a member of a group will return an array of the servers in its group.  The first server in that array represents the group, and its name is the name of the goup."
	| grp names server |
	names _ OrderedCollection new.
	Servers associationsDo: [:assn |
		server _ assn value.
		grp _ server group.  "Note: this is an association"
		(grp == nil or: [server == grp value first])
			ifTrue: [names add: server groupName]].
	^ names asSortedArray
