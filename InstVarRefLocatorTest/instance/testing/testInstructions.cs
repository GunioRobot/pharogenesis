testInstructions

	| scanner end printer methods |

	methods := Object methodDict values. 

	methods do: [:method |
		scanner _ InstructionStream on: method.
		printer _ InstVarRefLocator new.
		end _ scanner method endPC.

		[scanner pc <= end] whileTrue: [
			self shouldnt: [printer interpretNextInstructionUsing: scanner] raise: Error.
		].
	].