moveObject: aPersonalObject toAccount: anAccount
	"Transfer the ownership of the given personal object to <anAccount>."

	self removeObject: aPersonalObject.
	anAccount addObject: aPersonalObject