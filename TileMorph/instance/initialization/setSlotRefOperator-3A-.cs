setSlotRefOperator: aString
	"aString represents the name of a slot that the receiver is to represent; configure the receiver to serve thi duty, and set upthe wording on the tile appropriately"

	type _ #operator.
	operatorOrExpression _ ScriptingSystem getterSelectorFor: aString.
	operatorReadoutString _ aString.
 	self line1: aString