representsAType
	"Answer whether this vocabulary represents an end-user-sensible data type"

	"^ (self class == DataType) not"  "i.e. subclasses yes, myself no"
	"Assuming this is an abstract class"
	^true