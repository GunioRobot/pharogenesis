removeOldChangeSets
	"Ask the user to select a change set from a menu, then remove all change sets before the selected one."
	"ChangeSorter removeOldChangeSets" 

	| names stopName |
	self gatherChangeSets.
	names _ AllChangeSets collect: [:each | each name].
	stopName _ (SelectionMenu labelList: names selections: names) startUp.
	stopName ifNotNil: [self removeChangeSetsBefore: stopName].
