initCompactClasses 
	| c |
	c _ Array new: 31.	
	"These classes have a short name (their index in this table.  It is not their oop.)
	Thus their instances can use just a single word as their header in memory."
	c at: 1 put: CompiledMethod.  c at: 2 put: Symbol. c at: 3 put: Array.
	c at: 4 put: Float.  c at: 5 put: LargePositiveInteger.  c at: 6 put: String.
	c at: 7 put: MethodDictionary.  c at: 8 put: Association.  c at: 9 put: Point.
	c at: 10 put: Rectangle.  c at: 11 put: ClassOrganizer.  c at: 12 put: TextLineInterval.

	"**NOTE** at present the Squeak VM relies on BlockContext=13 and MethodContext=14"
	c at: 13 put: BlockContext.  c at: 14 put: MethodContext.  c at: 15 put: PseudoContext.

	compactClasses _ c.
	"16 to 31 are available for user defined compact classes."

	"Attempt to correctly write contextCache image.."
	"compactClasses _ Smalltalk compactClassesArray"