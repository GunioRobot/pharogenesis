closeGroup
	"Close connection with all servers in the group."

	(group
		ifNil: [Array with: self]
		ifNotNil: [group value]) do: [:aDir | aDir quit].
