name
	"The name of this changeSet.
	 2/7/96 sw: If name is nil, we've got garbage.  Help to identify."

	^ name == nil
		ifTrue:
			['<no name -- garbage?>']
		ifFalse:
			[name]