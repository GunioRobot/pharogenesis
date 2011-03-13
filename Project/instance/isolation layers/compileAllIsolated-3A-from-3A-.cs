compileAllIsolated: newClass from: oldClass
	"Whenever a recompile is needed in a class, look in other isolated projects for saved methods and recompile them also.
	At the time this method is called, the recompilation has already been done for the project now in force."

	Project allProjects do: [:proj | proj compileAll: newClass from: oldClass].

