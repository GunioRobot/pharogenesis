fillAggregateChangeSet
	"Create a change-set named Aggregate and pour into it all the changes in all the change-sets of the currently-selected category"

	| aggChangeSet |
	aggChangeSet :=  ChangeSorter assuredChangeSetNamed: #Aggregate.
	aggChangeSet clear.
	aggChangeSet setPreambleToSay: '"Change Set:		Aggregate
Created at ', Time now printString, ' on ', Date today printString, ' by combining all the changes in all the change sets in the category ', categoryName printString, '"'.

	(self elementsInOrder copyWithout: aggChangeSet) do:
		[:aChangeSet  | aggChangeSet assimilateAllChangesFoundIn: aChangeSet].
	SystemWindow wakeUpTopWindowUponStartup
