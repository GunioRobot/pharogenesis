gridSizeFor: aPoint
	"returns appropriate size for specified argument"
	| g |
	g _ aPoint x min: aPoint y.
	g <= 256 ifTrue: [^8].
	^16.