tallyCPUUsageFor: seconds every: msec
	"Compute CPU usage using a msec millisecond sample for the given number of seconds,
	then dump the usage statistics on the Transcript. The UI is free to continue, meanwhile"
	"ProcessBrowser tallyCPUUsageFor: 10 every: 100"

	| promise |
	promise _ Processor tallyCPUUsageFor: seconds every: msec.

	[ | tally |
		tally _ promise value.
		Smalltalk isMorphic
			ifTrue: [ WorldState addDeferredUIMessage: [ self dumpTallyOnTranscript: tally ] ]
			ifFalse: [ [ Transcript open ] forkAt: Processor userSchedulingPriority.
					[ (Delay forSeconds: 1) wait.
					self dumpTallyOnTranscript: tally ] forkAt: Processor userSchedulingPriority.]
	] fork.