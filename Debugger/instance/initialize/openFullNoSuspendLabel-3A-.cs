openFullNoSuspendLabel: aString
	"Create and schedule a full debugger with the given label. Do not terminate the current active process."

	| topView |
	Smalltalk isMorphic ifTrue:
		[self openFullMorphicLabel: aString.
		^ Project current spawnNewProcessIfThisIsUI: interruptedProcess].
	topView _ self buildMVCDebuggerViewLabel: aString minSize: 300@200.
	topView controller openNoTerminate.
	^ topView
