formatOf: obj
	"Make the code that tells the format of this object.
	It is like the class's instSpec, but with added low bits for byte size"
"       0=      No pointer fields
        1=      Fixed pointer fields only
        2=      Var pointer fields only
        3=      Fixed and var pointer fields
        4=      both fixed and indexable weak fields

        5=      unused
        6=      var long (bit) fields only
        7=      unused
 
        8-11=   var byte fields only
                low 2 bits are low 2 bits of size **
        12-15   methods -- ie #literals in header, followed by var bytes
                same interpretation of low 2 bits"
	| class spec |
	class _ obj class.
	spec _ class instSpec.    "just use what's there"
	spec < 8 ifTrue: [^ spec]
			ifFalse: ["For byte objects, size = wordSize - spec.lowBits"
					^ spec + (3 - (obj size+3 bitAnd: 3))]