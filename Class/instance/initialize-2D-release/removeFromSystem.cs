removeFromSystem
	"Forget the receiver from the Smalltalk global dictionary. Any existing 
	instances will refer to an obsolete version of the receiver."

	self environment removeClassFromSystem: self.
	self obsolete