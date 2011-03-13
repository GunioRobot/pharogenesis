hasInstVarRef
	"Answer whether the receiver references an instance variable."

	| method scanner end printer |

	home ifNil: [^false].
	method _ self method.
	"Determine end of block from long jump preceding it"
	end _ (method at: startpc-2)\\16-4*256 + (method at: startpc-1) + startpc - 1.
	scanner _ InstructionStream new method: method pc: startpc.
	printer _ InstVarRefLocator new.

	[scanner pc <= end] whileTrue: [
		(printer interpretNextInstructionUsing: scanner) ifTrue: [^true].
	].
	^false