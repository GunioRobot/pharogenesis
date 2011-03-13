computeFillLists
	"Compute the fill index lists"
	| leftFills rightFills |
	leftFills:= leftFillList contents as: ShortRunArray.
	rightFills := rightFillList contents as: ShortRunArray.
	^Array with: leftFills with: rightFills