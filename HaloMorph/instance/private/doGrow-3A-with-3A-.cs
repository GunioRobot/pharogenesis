doGrow: evt with: growHandle
	"Called while the mouse is down in the grow handle"

	| newExtent extentToUse scale |
	evt hand obtainHalo: self.
	newExtent _ (target pointFromWorld: (target griddedPoint: evt cursorPoint - positionOffset))
								- target topLeft.
	evt shiftPressed ifTrue: [
		scale _ (newExtent x / (originalExtent x max: 1)) min:
					(newExtent y / (originalExtent y max: 1)).
		newExtent _ (originalExtent x * scale) asInteger @ (originalExtent y * scale) asInteger
	].
	(newExtent x < 1 or: [newExtent y < 1 ]) ifTrue: [^ self].
	target renderedMorph setExtentFromHalo: (extentToUse _ newExtent).
	growHandle position: evt cursorPoint - (growHandle extent // 2).
	self layoutChanged.
	(self valueOfProperty: #commandInProgress) ifNotNilDo:  
		[:cmd | "Update the final extent"
		cmd redoTarget: target selector: #setExtentFromHalo: argument: extentToUse]
