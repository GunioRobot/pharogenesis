testPreMultiplyByMatrix
	| array matrix result|.
	array := #(1 2 3 4 5).
	
	"( 1  2  3  4  5
	  10 20 30 40 50)"
	matrix := Matrix
				rows:2 columns:5 tabulate: [:row :column | row = 1 
											ifTrue: column
											ifFalse: column * 10].
	result := array preMultiplyByMatrix: matrix.
	self assert: result isArray.
	self assert: result size = 2.
	self assert: result first = 55.
	self assert: result second = 550.