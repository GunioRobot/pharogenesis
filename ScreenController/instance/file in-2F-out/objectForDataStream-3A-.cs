objectForDataStream: refStrm
	| dp |
	"I am about to be written on an object file.  Write a path to me in the other system instead."

	dp _ DiskProxy global: #ScheduledControllers selector: #screenController args: #().
	refStrm replace: self with: dp.
	^ dp