objectForDataStream: refStrm
	"I am about to be written on an object file.  Write a path to me in the other system instead."

	^ DiskProxy global: #ScheduledControllers selector: #screenController args: #()