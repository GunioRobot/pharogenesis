initialize
	"Initialize class variables specifying the size of the temporary frame
	needed to run instances of me."

	SmallFrame _ 12.	"Context range for temps+stack"
	LargeFrame _ 32

	"CompiledMethod initialize"