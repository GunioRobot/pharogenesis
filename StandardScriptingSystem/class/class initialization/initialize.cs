initialize
	"StandardScriptingSystem initialize"
	"Sometimes this method is vacuously changed just to get it in a changeset so that its invocation will occur as part of an update"

	(Smalltalk at: #ScriptingSystem ifAbsent: [nil]) ifNil:
		[Smalltalk at: #ScriptingSystem put: self new].

	ScriptingSystem
		initStandardSlotInfo;
		initCategoryElementDictionary;
		initStandardScriptInfo;
		initializeSystemSlotDictionary;
		initializeHelpStrings