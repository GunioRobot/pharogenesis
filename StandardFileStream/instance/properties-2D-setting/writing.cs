writing
	"Answer whether the receiver is in the process of writing.  Probably obsolete -- only sender outside of HFS-specific code is in FileStream>>close, which is, in effect, abstract, and not actually reached now.  I THINK.  2/12/96 sw"

	^ rwmode