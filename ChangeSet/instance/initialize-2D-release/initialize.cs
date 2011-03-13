initialize 
	"Reset the receiver to be empty."

	self wither.  "Avoid duplicate entries in AllChangeSets if initialize gets called twice"
	classChanges _ Dictionary new.
	methodChanges _ Dictionary new.
	classRemoves _ Set new.
	name _ ChangeSet defaultName