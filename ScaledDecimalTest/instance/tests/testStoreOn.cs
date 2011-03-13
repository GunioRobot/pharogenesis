testStoreOn
	"this is http://bugs.squeak.org/view.php?id=4378"
	
	"Both results should be 1.
	ScaledDecimal representations are exact
	(though only scale digits or fractional part are printed)"

	self assert:
    		(Compiler evaluate: (0.5s1 squared storeString)) * 4
		= (0.5s1 squared * 4)