groupNamed: nameString
	"Return the first server in the group of this name."
	| grp server |
	Servers associationsDo: [:assn |
		server _ assn value.
		grp _ server group.  "Note: this is an association"
		(grp == nil or: [server == grp value first])
			ifTrue: [nameString = server groupName
						ifTrue: [^ server]]].
	^ self error: 'Server name not found'
