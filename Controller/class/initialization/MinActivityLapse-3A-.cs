MinActivityLapse: milliseconds
	"minimum time to delay between calls to controlActivity"
	MinActivityLapse _ milliseconds ifNotNil: [ milliseconds rounded ].