onDatabase: aMailDB
	"create a Celeste instance on the given MailDB.  The database may safely be nil"
	self == Celeste ifTrue: [
		"don't open the abstract class"
		^self interfaceClass onDatabase: aMailDB ].

	^super new openOnDatabase: aMailDB