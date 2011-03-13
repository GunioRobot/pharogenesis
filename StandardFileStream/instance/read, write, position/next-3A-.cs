next: n
	"Return a string with the next n characters of the filestream in it.  1/31/96 sw"
	^ self nextInto: (buffer1 class new: n)