stepListSortBlock

	| answer |

	"Please pardon the hackery below. Since the block provided by this method is retained elsewhere, it is possible that the block argument variables would retain references to objects that were no longer really needed. In one case, this feature resulted in doubling the size of a published project."

	^[ :stepMsg1 :stepMsg2 | 
		answer _ stepMsg1 scheduledTime <= stepMsg2 scheduledTime.
		stepMsg1 _ stepMsg2 _ nil.
		answer
	]