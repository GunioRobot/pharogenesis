countReallyObsoleteClassesAndMetaclasses
	"Counting really obsolete classes and metaclasses"

	| metaSize classSize |
	Smalltalk garbageCollect.
	metaSize _ self reallyObsoleteMetaclasses size.
	Transcript cr; show: 'Really obsolete metaclasses: ', metaSize printString.
	classSize _ self reallyObsoleteClasses size.
	Transcript cr; show: 'Really obsolete classes: ', classSize printString; cr.
	"Metaclasses must correspond to classes!"
	metaSize ~= classSize 
		ifTrue: [self error: 'Serious metalevel inconsistency!!'].