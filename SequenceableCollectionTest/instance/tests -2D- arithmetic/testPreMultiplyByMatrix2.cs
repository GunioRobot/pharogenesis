testPreMultiplyByMatrix2
	| array matrix|.
	
	array := #(1 2 3 4 5).
	matrix := Matrix rows:1 columns:4 tabulate: [:row :column | column].
	
	"Not compatible size"
	self should:[array preMultiplyByMatrix: matrix] raise: Error.