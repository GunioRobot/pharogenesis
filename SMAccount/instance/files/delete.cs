delete
	"Delete this account. First delete all SM objects we own
	and disconnect this account from those we co-maintain."

	objects do: [:o | o delete].
	coObjects do: [:co | co removeMaintainer: self].
	super delete
