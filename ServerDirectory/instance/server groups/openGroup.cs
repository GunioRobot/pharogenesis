openGroup
	"Open all servers in the group.  Don't forget to close later."

	(group
		ifNil: [Array with: self]
		ifNotNil: [group value]) do: [:aDir | aDir wakeUp].
