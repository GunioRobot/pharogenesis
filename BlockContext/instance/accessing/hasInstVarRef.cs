hasInstVarRef
	"Answer whether the receiver references an instance variable."

	| method scanner end printer |

	home ifNil: [^false].
	method _ self method.
	end _ self endPC.
	scanner _ InstructionStream new method: method pc: startpc.
	printer _ InstVarRefLocator new.

	[scanner pc <= end] whileTrue: [
		(printer interpretNextInstructionUsing: scanner) ifTrue: [^true].
	].
	^false