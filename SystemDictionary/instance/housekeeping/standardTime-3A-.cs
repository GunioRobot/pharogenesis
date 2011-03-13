standardTime: aBlock
	"Times the execution of aBlock in milliseconds, under the following standard conditions:  exactly 10Mb of free space is available and compacted, and the recent VM statistics are reset immediately before execution."
	| spaceLeft tieDown |
	spaceLeft _ Smalltalk garbageCollect.
	spaceLeft < 1e7 ifTrue: [self error: 'not enough space for standard conditions'].
	tieDown _ ByteArray new: spaceLeft - 1e7.  "Leave exactly 10MB free"
	tieDown _ tieDown.
	Utilities vmStatisticsReportString.  "To reset statistics"
	Smalltalk garbageCollectMost.  "To clear that garbage"
	^ Time millisecondsToRun: aBlock