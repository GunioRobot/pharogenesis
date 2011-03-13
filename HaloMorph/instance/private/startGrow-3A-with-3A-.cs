startGrow: evt with: growHandle
	| botRt |
	"Initialize resizing of my target.  Launch a command representing it, to support Undo"
	evt hand obtainHalo: self.
	growingOrRotating _ true.
	self removeAllHandlesBut: growHandle.  "remove all other handles"
	botRt _ target point: target bottomRight in: owner.
	(self world viewBox containsPoint: botRt)
		ifTrue: [positionOffset _ evt cursorPoint - botRt]
		ifFalse: [positionOffset _ 0@0].
	self setProperty: #commandInProgress toValue:
		(Command new
			cmdWording: 'resizing';
			undoTarget: target selector: #extent: argument: target extent)
