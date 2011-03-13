clear
	"Clear out the model in the image. This will forget
	about what packages are installed and what versions.
	The map is itself on disk though and will be reloaded.
	
	If you only want to reload the map and not forget about
	installed packages then use 'SMSqueakMap default reload'.

	If you want to throw out the map perhaps when shrinking
	an image, then use 'SMSqueakMap default purge'."

	"SMSqueakMap clear"

	DefaultMap := nil