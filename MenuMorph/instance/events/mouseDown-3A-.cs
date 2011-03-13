mouseDown: evt
	"Handle a mouse down event."
	(stayUp or:[self fullContainsPoint: evt position]) 
		ifFalse:[^self deleteIfPopUp: evt]. "click outside"
	self isSticky ifTrue: [^self].
	"Grab the menu and drag it to some other place"
	evt hand grabMorph: self.