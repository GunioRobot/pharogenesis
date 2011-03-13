stopRunningAll
	"Reset all ticking scripts to be paused.  Triggered by user hitting STOP button"

	self presenter allExtantPlayers do:
		[:aPlayer |
		aPlayer stopRunning].
	self allScriptors do:
		[:aScript | aScript pauseIfTicking].

	self world updateStatusForAllScriptEditors