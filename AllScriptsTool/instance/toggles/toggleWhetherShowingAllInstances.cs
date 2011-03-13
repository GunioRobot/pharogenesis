toggleWhetherShowingAllInstances
	"Toggle whether the receiver is showing all instances or only one exemplar per uniclass"

	showingAllInstances _ showingAllInstances not.
	presenter updateContentsFor: self