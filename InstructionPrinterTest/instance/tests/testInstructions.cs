testInstructions
	"just print all of methods of Object and see if no error accours"

	| methods printer  |
	
	methods := Object methodDict values. 
	printer  := InstructionPrinter.	

	methods do: [:method |
					self shouldnt: [ 
						String streamContents: [:stream | 
							(printer on: method) printInstructionsOn: stream]] raise: Error.
			].
