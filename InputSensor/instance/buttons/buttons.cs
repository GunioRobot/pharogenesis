buttons
	"Answer the result of primMouseButtons, but swap the mouse  
	buttons if Preferences swapMouseButtons is set."
	^ ButtonDecodeTable at: self primMouseButtons + 1