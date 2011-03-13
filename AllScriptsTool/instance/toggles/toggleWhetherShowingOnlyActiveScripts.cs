toggleWhetherShowingOnlyActiveScripts
	"Toggle whether the receiver is showing only active scripts"

	showingOnlyActiveScripts _ showingOnlyActiveScripts not.
	presenter updateContentsFor: self