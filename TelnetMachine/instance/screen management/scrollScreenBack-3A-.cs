scrollScreenBack: numLines
	"scrolls the screen up by the number of lines.  The cursor isn't moved"
	numLines timesRepeat: [ displayLines removeFirst ].
	numLines timesRepeat: [
		displayLines addLast: (Text new: 80 withAll: Character space) ].