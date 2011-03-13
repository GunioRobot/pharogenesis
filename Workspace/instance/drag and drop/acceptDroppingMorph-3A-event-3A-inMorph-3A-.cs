acceptDroppingMorph: dropee event: evt inMorph: targetMorph 
	"Return the dropee to its old position, and add a reference to it at the cursor point."
	| bindingName |

	bindingName _  dropee externalName translateToLowercase, dropee identityHash printString..
	targetMorph correctSelectionWithString: bindingName, ' '.
	(self bindingOf: bindingName) value: dropee.
	dropee rejectDropMorphEvent: evt.
	^ true "success"
