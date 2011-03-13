openFullNoSuspendLabel: aString
	"Create and schedule a full debugger with the given label. Do not terminate the current active process."

	| topView |

	Smalltalk isMorphic ifTrue: [
		self openFullMorphicLabel: aString.
		errorWasInUIProcess _ CurrentProjectRefactoring newProcessIfUI: interruptedProcess.
		^self
	].
	topView _ self buildMVCDebuggerViewLabel: aString minSize: 300@200.
	topView controller openNoTerminate.
	^ topView
