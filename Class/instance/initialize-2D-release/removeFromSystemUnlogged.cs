removeFromSystemUnlogged
	"Forget the receiver from the Smalltalk global dictionary. Any existing instances will refer to an obsolete version of the receiver.  Do not log the removal either to the current change set nor to the system changes log"

	Smalltalk removeClassFromSystemUnlogged: self.
	self obsolete