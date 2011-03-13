testInstructions
	"just interpret all of methods of Object"

	| methods client scanner|
	
	methods := Object methodDict values. 
	client := InstructionClient new.	

	methods do: [:method |
			scanner := (InstructionStream on: method).
			[scanner pc <= method endPC] whileTrue: [
					self shouldnt: [scanner interpretNextInstructionFor: client] raise: Error.
			].
	].
