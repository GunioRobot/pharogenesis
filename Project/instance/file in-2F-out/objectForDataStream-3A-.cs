objectForDataStream: refStrm
	| uu |
	"I am about to be written on an object file.  Write a path to me in the other system instead."

	(uu _ self url) size > 0 ifTrue: [
		^ DiskProxy global: #Project selector: #namedUrl: args: 
			(Array with: uu)].

	^ DiskProxy global: #Project selector: #named: args: (Array with: self name)

"	self inform: 'Project ', self name, ' is being written'.
	super objectForDataStream: refStrm.
"