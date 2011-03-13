objectForDataStream: refStrm
	| dp |
	"I am about to be written on an object file.  Write a path to me in the other system instead."

	dp _ DiskProxy global: #Processor selector: #yourself args: #().
	refStrm replace: self with: dp.
	^ dp
