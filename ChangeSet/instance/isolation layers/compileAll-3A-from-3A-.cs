compileAll: newClass from: oldClass
	"If I have changes for this class, recompile them"

	(changeRecords at: newClass ifAbsent: [^ self])
		compileAll: newClass from: oldClass
