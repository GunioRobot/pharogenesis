do: aBlock
	"Singleton objects just upply themselves to the block"
	"This is a convenient way to bind a simple variable
	to the result of some expression"
	^ aBlock value: self