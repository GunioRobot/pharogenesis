cleanupsForRelease
	"Miscellaneous space cleanups to do before a release."
	"EToySystem cleanupsForRelease"

	Socket deadServer: ''.  "Don't reveal any specific server name"
	HandMorph initialize.  "free cached ColorChart"
	PaintBoxMorph releaseTemporaryForms.
	PaintBoxMorph prototype stampHolder clear.  "clear stamps"
	PaintBoxMorph prototype delete.  "break link to world, if any"
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