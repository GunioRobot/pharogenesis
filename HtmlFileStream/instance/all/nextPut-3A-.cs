nextPut: char
	"Put a character on the file, but translate it first. 4/6/96 tk"
	char = $< ifTrue: [^ super nextPutAll: '&lt;'].
	char = $> ifTrue: [^ super nextPutAll: '&gt;'].
	char = $& ifTrue: [^ super nextPutAll: '&amp;'].
	char asciiValue = 13 "return" ifTrue: [
			self command: 'br'].
	char = $	"tab" ifTrue:
		[super nextPut: char.  ^ self verbatim: TabThing].
	^ super nextPut: char