choosePartName
	"When I am renamed, get a slot, make default methods, move any existing methods."
	| old |
	(self pasteUpMorph model isKindOf: Component) ifTrue:
		[self knownName ifNil: [^ self nameMeIn: self pasteUpMorph]
					ifNotNil: [^ self renameMe]].
	old _ slotName.
	super choosePartName.
	slotName ifNil: [^ self].  "user chose bad slot name"
	self model: self world model slotName: slotName.
	old == nil 
		ifTrue: [self compilePropagationMethods]
		ifFalse: [self copySlotMethodsFrom: old].
			"old ones not erased!"