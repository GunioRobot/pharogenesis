toggleWhetherShowingOnlyActiveScripts
	"Toggle whether the receiver is showing only active scripts"

	showingOnlyActiveScripts _ showingOnlyActiveScripts not.
	self presenter reinvigorateAllScriptsTool: self