atWrap: anInteger 
	"Answer the anInteger'th element.  If index is out of bounds, let it wrap around from the end to the beginning unil it is in bounds.  6/18/96 tk"

^ self at: (anInteger - self increment \\ self size + self increment)