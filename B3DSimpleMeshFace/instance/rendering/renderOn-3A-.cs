renderOn: aRenderer
	^aRenderer trackEmissionColor: true;		"Turn on pre-lit colors"
			drawPolygonAfter:[
		aRenderer normal: self normal.
		1 to: self size do:[:i| (self at: i) renderOn: aRenderer].
	].