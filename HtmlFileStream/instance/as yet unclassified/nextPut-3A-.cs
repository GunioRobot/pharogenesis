nextPut: char
	"Put a character on the file, but translate it first. 4/6/96 tk"
	char = $< ifTrue: [^ super nextPutAll: '&lt;'].
	char = $> ifTrue: [^ super nextPutAll: '&gt;'].
	char = $& ifTrue: [^ super nextPutAll: '&amp;'].
	char asciiValue = 13 "return" ifTrue: [
			self command: 'br'].
	char = $	"tab" ifTrue: [self command: 'IMG SRC="tab.gif" ALT="    "'].
	^ super nextPut: char