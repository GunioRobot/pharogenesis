readFromFile
	"Read in a simple segment.  Use folder of this image, even if remembered as previous location of this image"

	| ff realName |
	realName _ self class folder, FileDirectory slash, self localName.
	ff _ FileStream readOnlyFileNamed: realName.
	segment _ ff nextWordsInto: (WordArrayForSegment new: ff size//4).
	endMarker _ segment nextObject. 	"for enumeration of objects"
	endMarker == 0 ifTrue: [endMarker _ 'End' clone].
	ff close.
	state _ #active