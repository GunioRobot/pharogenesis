nonTrivial 
	"Answer whether the receiver has any methods or instance variables."

	^ self instVarNames size > 0 or: [methodDict size > 0]