incCompBody
	"Move objects to consolidate free space into one big chunk. Return the newly created free chunk."

	| bytesFreed |
	self inline: false.
	"reserve memory for forwarding table"
	self fwdTableInit: 8.  "Two-word blocks"

	"assign new oop locations, reverse their headers, and initialize forwarding blocks"
	bytesFreed _ self incCompMakeFwd.

	"update pointers to point at new oops"
	self mapPointersInObjectsFrom: youngStart to: endOfMemory.

	"move the objects and restore their original headers; return the new free chunk"
	^ self incCompMove: bytesFreed