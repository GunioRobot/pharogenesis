okayToAddDismissHandle
	"Answer whether a halo on the receiver should offer a dismiss handle.  This provides a hook for making it harder to disassemble some strucures even momentarily"

	^ self holdsSeparateDataForEachInstance not  and:
		[self resistsRemoval not]