writeOn: file
	"Write the receiver out on the given file, in a format which can be subsequently read back in by the companion method readFrom:.  By di 5/96; lost in the color transition, recreated 7/10/96 tk"

	theForm writeOn: file.
	mask writeOn: file