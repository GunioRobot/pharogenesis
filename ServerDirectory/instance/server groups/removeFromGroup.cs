removeFromGroup
	"Allowable if not in a group presently"
	group ifNotNil:
		["Group is an association shared by all members.
		Therefore all will feel this removal"
		group value: (group value copyWithout: self).
		group _ nil  "...and I'm outa here"]