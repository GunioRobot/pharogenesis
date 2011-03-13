newChangeSet: aName
	"Makes a new change set called aName, add author initials to try to
	ensure a unique change set name."

	| newName |
	newName _ aName , FileDirectory dot , Utilities authorInitials.
	^ self basicNewChangeSet: newName