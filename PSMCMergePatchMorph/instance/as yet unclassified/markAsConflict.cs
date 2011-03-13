markAsConflict
	"Mark the conflict as unresolved."
	
	self selectedChangeWrapper clearChoice.
	self changed: #changes.
	self updateSource.