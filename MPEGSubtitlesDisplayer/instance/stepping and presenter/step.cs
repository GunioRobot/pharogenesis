step
	"update my position"
	super step.
	" 
	if my owner is the mpegplayer, i change my position to  
	bottomCenter"
	self owner == self target
		ifTrue: [| bc | 
			bc := self owner bottomCenter.
			self left: bc x - (self width // 2).
			self bottom: bc y]