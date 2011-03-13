cleanupsForRelease
	"Miscellaneous space cleanups to do before a release."
	"EToySystem cleanupsForRelease"

	Socket deadServer: ''.  "Don't reveal any specific server name"
	HandMorph initialize.  "free cached ColorChart"
	PaintBoxMorph initialize.	"forces Prototype to let go of extra things it might hold"
	Smalltalk removeKey: #AA ifAbsent: [].
	Smalltalk removeKey: #BB ifAbsent: [].
	Smalltalk removeKey: #CC ifAbsent: [].
	Smalltalk removeKey: #DD ifAbsent: [].
	Smalltalk removeKey: #Temp ifAbsent: [].

	ScriptingSystem reclaimSpace.
	Smalltalk cleanOutUndeclared.
	Smalltalk reclaimDependents.
	Smalltalk forgetDoIts.
	Smalltalk removeEmptyMessageCategories.
	Symbol rehash