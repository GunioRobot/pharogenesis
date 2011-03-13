doGrow: evt with: growHandle
	"Called while the mouse is down in the grow handle"

	| newExtent extentToUse |
	evt hand obtainHalo: self.
	newExtent _ (target pointFromWorld: (target griddedPoint: evt cursorPoint - positionOffset))
								- target topLeft.
	evt shiftPressed ifTrue: [newExtent _ (newExtent x max: newExtent y) asPoint].
	target renderedMorph extent: (extentToUse _ newExtent).
	growHandle position: evt cursorPoint - (growHandle extent // 2).
	self layoutChanged.
	(self valueOfProperty: #commandInProgress) doIfNotNil:  
		[:cmd | "Update the final extent"
		cmd redoTarget: target selector: #extent: argument: extentToUse]
