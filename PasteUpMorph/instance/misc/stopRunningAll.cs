stopRunningAll
	"Stop running all scripted morphs.  Triggered by user hitting STOP button"

	self presenter allExtantPlayers do: [:aPlayer |
		aPlayer stopRunning].
	self world updateStatusForAllScriptEditors