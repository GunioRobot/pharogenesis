copyClass
	| copysName |
	classListIndex = 0
		ifTrue: [^ self].
	self okToChange
		ifFalse: [^ self].
	copysName := self request: 'Please type new class name' initialAnswer: self selectedClass name.
	copysName isEmptyOrNil
		ifTrue: [^ self].
	"Cancel returns ''"
	self selectedClass duplicateClassWithNewName: copysName.
	self classListIndex: 0.
	self changed: #classList