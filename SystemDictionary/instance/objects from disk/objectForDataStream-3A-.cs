objectForDataStream: refStrm
	"I am about to be written on an object file.  Write a reference to Smalltalk instead."

	^ DiskProxy global: #Smalltalk selector: #yourself
			args: #()