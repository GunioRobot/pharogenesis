lock 
	"Refer to the comment in View|lock.  Must do what would be done by displaying..."

	self isUnlocked ifTrue: [self positionText].
	super lock