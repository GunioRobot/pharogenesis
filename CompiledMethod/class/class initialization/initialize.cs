initialize    "CompiledMethod initialize"
	"Initialize class variables specifying the size of the temporary frame
	needed to run instances of me."

	SmallFrame _ 16.	"Context range for temps+stack"
	LargeFrame _ 56.

	self classPool at: #BlockNodeCache ifAbsentPut: [nil->nil].