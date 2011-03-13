cleanupAndCheckClassHierarchy
	"Makes the class hierarchy consistent and removes obsolete classes from the SystemDictionary.
	Afterwards it checks whether the hierarchy is really consistent."
	UIManager default informUserDuring: [ :bar | self cleanupAndCheckClassHierarchy: bar ]