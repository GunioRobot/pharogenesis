initialize 
	"Reset the receiver to be empty."

	revertable _ false.
	self clear.
 	"Avoid duplicate entries in AllChanges if initialize gets called twice"
	name _ ChangeSet defaultName.
