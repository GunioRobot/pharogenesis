colorMap: map
	"See last part of BitBlt comment. 6/18/96 tk"
	(map notNil and:[map isColormap])
		ifTrue:[colorMap _ map colors]
		ifFalse:[colorMap _ map]