verifyChanges		"Smalltalk verifyChanges"
	"Recompile all methods in the changes file."
	Smalltalk allBehaviorsDo: [:class | class recompileChanges].
