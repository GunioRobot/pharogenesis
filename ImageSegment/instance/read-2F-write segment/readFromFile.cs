readFromFile
	"Read in a simple segment.  Use folder of this image, even if remembered as previous location of this image"

	| ff realName |
	realName := self class folder, FileDirectory slash, self localName.
	ff := FileStream readOnlyFileNamed: realName.
	segment := ff nextWordsInto: (WordArrayForSegment new: ff size//4).
	endMarker := segment nextObject. 	"for enumeration of objects"
	endMarker == 0 ifTrue: [endMarker := 'End' clone].
	ff close.
	state := #active