handleListenEvent: anEvent
	"We're listen for possible drop events here to add back those handles after a dup/grab operation"
	(anEvent isMouse and:[anEvent isMove not]) ifFalse:[^self]. "not interested"
	anEvent hand removeMouseListener: self. "done listening"
	self addHandles. "and get those handles back"