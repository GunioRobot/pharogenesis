tally: context by: count
	"Explicitly tally the specified context and its stack."
	| root |
	context method == method ifTrue: [^self bumpBy: count].
	(root _ context home sender) == nil
		ifTrue: [^ (self bumpBy: count) tallyPath: context by: count].
	^ (self tally: root by: count) tallyPath: context by: count