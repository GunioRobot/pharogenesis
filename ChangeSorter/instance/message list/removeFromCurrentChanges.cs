removeFromCurrentChanges
	"Redisplay after removal in case we are viewing the current changeSet"

	super removeFromCurrentChanges.
	currentSelector _ nil.
	self showChangeSet: myChangeSet