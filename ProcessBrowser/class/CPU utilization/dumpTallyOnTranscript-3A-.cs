dumpTallyOnTranscript: tally
	"tally is from ProcessorScheduler>>tallyCPUUsageFor:
	Dumps lines with percentage of time, hash of process, and a friendly name"

	tally sortedCounts do: [ :assoc | | procName |
		procName _ (self nameAndRulesFor: assoc value) first.
		Transcript print: (((assoc key / tally size) * 100.0) roundTo: 1);
			nextPutAll: '%   ';
			print: assoc value identityHash; space;
			nextPutAll: procName;
			cr.
	].
	Transcript flush.