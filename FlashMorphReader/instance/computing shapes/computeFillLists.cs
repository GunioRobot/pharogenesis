computeFillLists
	"Compute the fill index lists"
	| leftFills rightFills |
	leftFills_ leftFillList contents as: ShortRunArray.
	rightFills _ rightFillList contents as: ShortRunArray.
	^Array with: leftFills with: rightFills