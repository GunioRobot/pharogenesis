text: s at: pt font: fontOrNil color: c

	^ self text: s bounds: (pt extent: 10000@10000) font: fontOrNil color: c
