optimizeMeshLayout
	"Optimize the layout of the indexed mesh for primitive operations.
	Optimzed layouts include triangle/quad strips and fans and 
	will result in MUCH better performance during rendering.
	However, optimizations are generally time-consuming so
	you better don't call this method too often."
	^self "Must be implemented in my subclasses"