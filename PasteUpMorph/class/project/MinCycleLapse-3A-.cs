MinCycleLapse: milliseconds
	"set the minimum amount of time that may transpire between two calls to doOneCycle"
	MinCycleLapse _ milliseconds ifNotNil: [ milliseconds rounded ].