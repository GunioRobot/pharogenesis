initialize
	"Initialize the receiver (automatically called when instances are created via 'new')"

	super initialize.
	vocabularyName :=  #Public.
	self documentation: '"Public" is vocabulary that excludes categories that start with "private" and methods that start with "private" or "pvt"'