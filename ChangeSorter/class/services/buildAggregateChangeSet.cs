buildAggregateChangeSet
	"Establish a change-set named Aggregate which bears the union of all the changes in all the existing change-sets in the system (other than any pre-existing Aggregate).  This can be useful when wishing to discover potential conflicts between a disk-resident change-set and an image.  Formerly very useful, now some of its unique contributions have been overtaken by new features"

	| aggregateChangeSet |
	aggregateChangeSet _ self existingOrNewChangeSetNamed: 'Aggregate'.
	aggregateChangeSet clear.
	(self gatherChangeSets copyWithout: aggregateChangeSet) do:
		[:aChangeSet | aggregateChangeSet assimilateAllChangesFoundIn: aChangeSet]

"ChangeSorter buildAggregateChangeSet"

	