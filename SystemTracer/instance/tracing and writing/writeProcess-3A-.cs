writeProcess: obj 
	"Substitute new initialProcess for current."
	| newObj instSize |
	newObj _ obj == Processor activeProcess
			ifTrue: [initialProcess]
			ifFalse: [obj].
	self new: obj
		class: newObj class
		length: (instSize _ newObj class instSize)
		trace: [1 to: instSize do:
				[:i | self trace: (newObj instVarAt: i)]]
		write: [1 to: instSize do:
				[:i | self writePointerField: (newObj instVarAt: i)]]