mapValues: mapBlock
	"NOTE: only meaningful to an entire set of runs"
	values _ values collect: [:val | mapBlock value: val]