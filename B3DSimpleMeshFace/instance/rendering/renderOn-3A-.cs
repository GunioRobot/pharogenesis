renderOn: aRenderer
	^aRenderer drawPolygonAfter:[
		aRenderer normal: self normal.
		1 to: self size do:[:i| (self at: i) renderOn: aRenderer].
	].