hasInstVarRef
	"Answer whether the receiver references an instance variable."

	| scanner end printer |

	scanner _ InstructionStream on: method.
	printer _ InstVarRefLocator new.
	end _ self method endPC.

	[scanner pc <= end] whileTrue: [
		(printer interpretNextInstructionUsing: scanner) ifTrue: [^true].
	].
	^false