objectForDataStream: refStrm
	"I am about to be written on an object file.  Write a path to me in the other system instead."

	^ DiskProxy global: #World selector: #primaryHand args: #()
	"Note, when this file is loaded in an MVC project, this will return nil.  The MenuItemMorph that has this in a field will have that item not work.  Maybe warn the user at load time?"