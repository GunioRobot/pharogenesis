initialize 
	"Initialize the receiver to be empty."

	name ifNil:
		[^ self error: 'All changeSets must be registered, as in ChangeSorter newChangeSet'].
	revertable _ false.
	self clear.
