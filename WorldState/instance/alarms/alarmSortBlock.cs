alarmSortBlock

	| answer |

	"Please pardon the hackery below. Since the block provided by this method is retained elsewhere, it is possible that the block argument variables would retain references to objects that were no longer really needed. In one case, this feature resulted in doubling the size of a published project."

	^[ :alarm1 :alarm2 | 
		answer _ alarm1 scheduledTime < alarm2 scheduledTime.
		alarm1 _ alarm2 _ nil.
		answer
	]