at: index setRunOffsetAndValue: aBlock 
	"Supply all run information to aBlock."
	"Tolerates index=0 and index=size+1 for copyReplace: "
	| run limit offset |
	limit _ runs size.
	(lastIndex == nil or: [index < lastIndex])
		ifTrue:  "cache not loaded, or beyond index - start over"
			[run _ 1.
			offset _ index-1]
		ifFalse:  "cache loaded and before index - start at cache"
			[run _ lastRun.
			offset _ lastOffset + (index-lastIndex)].
	[run <= limit and: [offset >= (runs at: run)]]
		whileTrue: 
			[offset _ offset - (runs at: run).
			run _ run + 1].
	lastIndex _ index.  "Load cache for next access"
	lastRun _ run.
	lastOffset _ offset.
	run > limit
		ifTrue: 
			["adjustment for size+1"
			run _ run - 1.
			offset _ offset + (runs at: run)].
	^aBlock
		value: run	"an index into runs and values"
		value: offset	"zero-based offset from beginning of this run"
		value: (values at: run)	"value for this run"