contents
	"Answer the contents of the file, reading it first if needed."

	contents _ self readContentsBrief: true.
	^ super contents.