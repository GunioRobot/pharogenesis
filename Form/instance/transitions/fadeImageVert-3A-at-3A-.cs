fadeImageVert: otherImage at: topLeft
	"Display fadeImageVert: (Form fromDisplay: (10@10 extent: 300@300)) reverse at: 10@10"
	^ self fadeImage: otherImage at: topLeft indexAndMaskDo:
		[:i :mask |
		mask fill: ((mask width//2//depth-i*depth)@0 extent: i*2*depth@mask height) fillColor: Color black.
		i <= (mask width//depth)]