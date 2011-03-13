convertToCurrentVersion: varDict refStream: smartRefStrm
	
	"20 dec 2000 - only a few (old) conversion exists"

	varDict at: 'mouseEnterLadenRecipient' ifPresent: [ :x | mouseEnterDraggingRecipient _ x].
	varDict at: 'mouseEnterLadenSelector' ifPresent: [ :x | mouseEnterDraggingSelector _ x].
	varDict at: 'mouseLeaveLadenRecipient' ifPresent: [ :x | mouseLeaveDraggingRecipient _ x].
	varDict at: 'mouseLeaveLadenSelector' ifPresent: [ :x | mouseLeaveDraggingSelector _ x].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

