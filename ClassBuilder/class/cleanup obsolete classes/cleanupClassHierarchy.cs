cleanupClassHierarchy
	"Makes the class hierarchy consistent and removes obsolete classes from the SystemDictionary."
	Utilities informUserDuring:[:bar|
		self cleanupClassHierarchy: bar.
	].