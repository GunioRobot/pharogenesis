propagateChanges
	"Assert these changes in the next higher isolation layer of the system."

	isolatedHead ifFalse: [self error: 'You can only assert changes from isolated projects'].
	self halt: 'Not Yet Implemented'.

"This will be done by installing a new changeSet for this project (initted for isolation).  With the old changeSet no longer in place, no revert will happen when we leave, and those changes will have effectively propagated up a level.  NOTE: for this to work in general, the changes here must be assimilated into the isolationSet for the next layer."