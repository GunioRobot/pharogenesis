experimentalCommand
	"Use for experimental command-key implementation.  using this, you can try things out without forever needing to reinitialize the ParagraphEditor. "
	sensor keyboard.

	self inform: 
'Cmd-t is not currently used.
To get "ifTrue: [" inserted, 
use Cmd-SHIFT-t'.
	^ true
