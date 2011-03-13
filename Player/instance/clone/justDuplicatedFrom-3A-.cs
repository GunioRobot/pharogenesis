justDuplicatedFrom: donorActor
	"Convert all references to actor1 to actor2, who now owns the script"
	"This is the case of true duplication, where the receiver and the donorPlayer are of distinct classes"

	self class userScriptsDo:
		[:aScript | aScript donorActor: donorActor ownActor: self; bringUpToDate]