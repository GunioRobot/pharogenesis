testBasic1

	| myObject myArray |
	myObject := Object new.
	myArray := {myObject . myObject}.
	self assert: (PointerFinder pointersTo: myObject) asArray = {myArray}