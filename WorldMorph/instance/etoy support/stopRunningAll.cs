stopRunningAll
	"Start running all scripted morphs.  Triggered by user hitting STOP button"

	self allExtantPlayers  do: [:aPlayer | aPlayer stopRunning.  aPlayer costume goHome].
	self updateStatusForAllScriptEditors