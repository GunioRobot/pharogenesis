testNoPointingObject

	| myObject |
	myObject := Object new.
	self assert: (PointerFinder pointersTo: myObject) isEmpty