startGrow: evt with: growHandle
	"Initialize resizing of my target.  Launch a command representing it, to support Undo"

	| botRt |
	self obtainHaloForEvent: evt andRemoveAllHandlesBut: growHandle.
	botRt _ target point: target bottomRight in: owner.
	positionOffset _ (self world viewBox containsPoint: botRt)
		ifTrue: [evt cursorPoint - botRt]
		ifFalse: [0@0].
	self setProperty: #commandInProgress toValue:
		(Command new
			cmdWording: 'resizing' translated;
			undoTarget: target selector: #setExtentFromHalo: argument: target extent).
	originalExtent _ target extent