hasInstVarRef: aMethod
	"Answer whether the receiver references an instance variable."

	| scanner end printer |

	scanner _ InstructionStream on: aMethod.
	printer _ InstVarRefLocator new.
	end _ scanner method endPC.

	[scanner pc <= end] whileTrue: [
		(printer interpretNextInstructionUsing: scanner) ifTrue: [^true].
	].
	^false