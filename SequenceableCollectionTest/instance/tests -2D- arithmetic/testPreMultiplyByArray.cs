testPreMultiplyByArray
	| array|.

	array := #(3).
	self assert:(array preMultiplyByArray: 2)=6.
	
	array := Array new: 4.
	self should:[array preMultiplyByArray: 2] raise:Error.