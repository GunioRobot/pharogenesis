changed
	"Update the fillStyle here."
	
	self setProperty: #fillStyle toValue: self fillStyleToUse.
	color := self fillStyle asColor.
	super changed