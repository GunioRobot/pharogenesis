toggleyGridding
	"Turn y (vertical) gridding off, if it is on, and turns it on, if it is off. 
	Does not change the primary tool."

	ygridOn
		ifTrue: 
			[grid := grid x @ 1.
			ygridOn := false]
		ifFalse: 
			[grid := grid x @ togglegrid y.
			ygridOn := true].
	tool := previousTool