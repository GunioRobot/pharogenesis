recompileAllTest
	"[Decompiler recompileAllTest]"
	"decompile every method and compile it back; if the decompiler is correct then the system should keep running.  :)"
	
	| decompiled ast compiled |
	SystemNavigation default allBehaviorsDo: [ :behavior |
		Utilities informUser: (behavior printString) during: [
			behavior selectors do: [ :sel |
				decompiled := Decompiler new decompile: sel in: behavior.
				ast := Compiler new compile: decompiled in: behavior notifying: nil ifFail: [ self error: 'failed' ].
				compiled := ast generate: (behavior compiledMethodAt: sel) trailer.
				behavior addSelector: sel withMethod: compiled. ] ] ]