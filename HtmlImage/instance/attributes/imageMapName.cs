imageMapName
	| imageMapName |
	(imageMapName _ self getAttribute: 'usemap')
		ifNil: [^nil].
	imageMapName first = $#
		ifTrue: [imageMapName _ imageMapName copyFrom: 2 to: imageMapName size].
	^imageMapName