openFile: aFileName
	"Open the given file (if not nil) in an instance of the receiver."

     | wrapper |
	aFileName ifNil: [^ Beeper beep].
     wrapper := self openOn: aFileName.
 	wrapper openInWorld.
     ^ wrapper