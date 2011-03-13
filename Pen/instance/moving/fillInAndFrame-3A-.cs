fillInAndFrame: aBlock
	"The argument, aBlock, should create a closed outline which is then 
	filled in with the current source form. Pens just evaluate the block; 
	subclasses can carry out the full method."

	^ aBlock value