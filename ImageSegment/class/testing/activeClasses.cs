activeClasses   "ImageSegment activeClasses"
	"Restore all remaining MD faults and return the active classes"

	| unused active |
	unused _ OrderedCollection new.
	active _ OrderedCollection new.
	Smalltalk allClasses do:
		[:c | (c instVarNamed: 'methodDict') 
			ifNil: [unused addLast: c]
			ifNotNil: [active addLast: c]].
	unused do: [:c | c recoverFromMDFault].
	^ active
