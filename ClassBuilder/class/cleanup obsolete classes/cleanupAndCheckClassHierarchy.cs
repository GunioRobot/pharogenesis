cleanupAndCheckClassHierarchy
	"Makes the class hierarchy consistent and removes obsolete classes from the SystemDictionary.
	Afterwards it checks whether the hierarchy is really consistent."
	Utilities informUserDuring:[:bar|
		self cleanupAndCheckClassHierarchy: bar.
	].
