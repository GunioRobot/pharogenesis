objectForDataStream: refStrm
	| dp |
	"I am about to be written on an object file.  Write a reference to the Display in the other system instead.  "

	"A path to me"
	dp _ DiskProxy global: #Display selector: #yourself args: #().
	refStrm replace: self with: dp.
	^ dp
