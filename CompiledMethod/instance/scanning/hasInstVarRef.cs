hasInstVarRef
	"Answer whether the method references an instance variable."

	| scanner end printer |

	scanner _ InstructionStream on: self.
	printer _ InstVarRefLocator new.
	end _ self endPC.

	[scanner pc <= end] whileTrue: [
		(printer interpretNextInstructionUsing: scanner) ifTrue: [^true].
	].
	^false