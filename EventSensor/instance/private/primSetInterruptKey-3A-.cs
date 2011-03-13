primSetInterruptKey: anInteger
	"Primitive. Register the given keycode as the user interrupt key. The low byte of the keycode is the ISO character and its next four bits are the Smalltalk modifer bits <cmd><opt><ctrl><shift>."
	interruptKey _ anInteger.
	"backward compatibility: use the old primitive which is obsolete now"
	super primSetInterruptKey: anInteger