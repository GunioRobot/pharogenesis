imageExtent
	"the image extent, according to the WIDTH and HEIGHT attributes.  returns nil if either WIDTH or HEIGHT is not specified"
	| widthText heightText |
	widthText _ self getAttribute: 'width' ifAbsent: [ ^nil ].
	heightText _ self getAttribute: 'height' ifAbsent: [ ^nil ].
	^ [ widthText asNumber @ heightText asNumber ] ifError: [ :a :b | nil ]