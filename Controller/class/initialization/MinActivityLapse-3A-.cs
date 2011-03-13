MinActivityLapse: milliseconds
	"minimum time to delay between calls to controlActivity"
	MinActivityLapse := milliseconds ifNotNil: [ milliseconds rounded ].