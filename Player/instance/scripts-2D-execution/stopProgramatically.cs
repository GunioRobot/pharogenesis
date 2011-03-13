stopProgramatically
	"stop running my ticking scripts -- called from running code"
	self instantiatedUserScriptsDo:
		[:aUserScript | aUserScript stopTicking]