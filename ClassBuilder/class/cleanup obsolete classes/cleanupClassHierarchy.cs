cleanupClassHierarchy
	"Makes the class hierarchy consistent and removes obsolete classes from the SystemDictionary."
	UIManager default informUserDuring: [ :bar | self cleanupClassHierarchy: bar ]