compileAll: newClass from: oldClass
	"Make sure that shadowed methods in isolation layers get recompiled.
	Traversal is done elsewhere.  This simply handles the current project."

	isolatedHead == true ifFalse: [^ self].   "only isolated projects need to act on this."
	
	changeSet compileAll: newClass from: oldClass