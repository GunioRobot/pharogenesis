useTempChangeSet
	"While reading the project in, use the temporary change set zzTemp"

	| zz |
	zz _ ChangeSorter changeSetNamed: 'zzTemp'.
	zz ifNil: [zz _ ChangeSorter basicNewChangeSet: 'zzTemp'].
	ChangeSet  newChanges: zz.