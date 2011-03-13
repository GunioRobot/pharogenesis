new: anInteger 
	"Create a collection with enough room allocated to contain up to anInteger elements.
	The new instance will be of size 0 (allocated room is not necessarily used)."
	
	^self basicNew setCollection: (Array new: anInteger)