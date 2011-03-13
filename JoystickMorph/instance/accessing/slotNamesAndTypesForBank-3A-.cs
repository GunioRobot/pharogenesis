slotNamesAndTypesForBank: aBank
	"Return an array of part names and part types for use in a viewer on the receiver's costumee; here we only put the costume-specific parts"

	aBank == 2 ifFalse: [^ Array new].

	^ #(

"		name			type		r/w			get selector			put selector
		-----------		---------		-----------	---------------------	-------------   "

		(leftRight	number		readOnly	getLeftRight				unused)
		(upDown	number		readOnly	getUpDown				unused)
		(angle		number		readOnly	getAngle				unused)
		(amount	number		readOnly	getAmount				unused))