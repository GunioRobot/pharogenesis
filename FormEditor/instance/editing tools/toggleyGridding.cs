toggleyGridding
	"Turn y (vertical) gridding off, if it is on, and turns it on, if it is off. 
	Does not change the primary tool."

	ygridOn
		ifTrue: 
			[grid _ grid x @ 1.
			ygridOn _ false]
		ifFalse: 
			[grid _ grid x @ togglegrid y.
			ygridOn _ true].
	tool _ previousTool