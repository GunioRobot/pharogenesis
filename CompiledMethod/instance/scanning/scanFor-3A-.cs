scanFor: byte 
	"Answer whether the receiver contains the argument as a bytecode."
	| instr |
	^ (InstructionStream on: self) scanFor: [:instr | instr = byte]
"
Smalltalk browseAllSelect: [:m | m scanFor: 134]
"