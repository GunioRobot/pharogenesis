objectForDataStream: refStrm
	"I am about to be written on an object file.  Write a path to me in the other system instead."

self == SystemOrganization ifTrue: [
	^ DiskProxy global: #SystemOrganization selector: #yourself args: #()].

^ self
