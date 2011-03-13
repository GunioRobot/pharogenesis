allObjectsDo: aBlock
	"Enumerate all objects that came from this segment.  NOTE this assumes that the segment was created (and extracted).  After the segment has been installed (install), this method allows you to enumerate its objects."
	| obj |

	endMarker ifNil: [^ self error: 'Just extract and install, don''t writeToFile:'].
	segment size ~= 1 ifTrue: [
		^ self error: 'Vestigial segment size must be 1 (version word)'].

	obj := segment nextObject.  "Start with the next object after the vestigial header"
	[obj == endMarker] whileFalse:  "Stop at the next object after the full segment"
		[aBlock value: obj.
		obj := obj nextObject].  "Step through the objects installed from the segment."