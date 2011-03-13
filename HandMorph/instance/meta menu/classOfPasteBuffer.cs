classOfPasteBuffer
	"avoids the weight of duplication but preserves privacy of PasteBuffer, for when we only need to know the *type* of data on the buffer, for arming menus"
	^ PasteBuffer class