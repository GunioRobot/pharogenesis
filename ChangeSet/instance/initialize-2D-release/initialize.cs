initialize 
	"Reset the receiver to be empty."

	self wither.  "Avoid duplicate entries in AllChangeSets if initialize gets called twice"
	name _ ChangeSet defaultName