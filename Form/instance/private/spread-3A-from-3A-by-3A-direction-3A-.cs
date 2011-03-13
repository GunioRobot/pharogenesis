spread: rect from: sourceForm by: scale direction: dir
	| port |
	port _ BitBlt toForm: self.
	dir == #horiz
	ifTrue:
		[0 to: width-1 do: 
			[:i |  "slice up original area"
			port copy: (i@0 extent: 1@height)
				from: rect topLeft+((i asFloat/scale) truncated@0)
				in: sourceForm fillColor: nil rule: Form over]]
	ifFalse:
		[0 to: height-1 do: 
			[:i |  "slice up original area"
			port copy: (0@i extent: width@1)
				from: rect topLeft+(0@(i asFloat/scale) truncated)
				in: sourceForm fillColor: nil rule: Form over]]