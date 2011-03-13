cornerPoint: cornerName
	"Given the name of a corner of the rect, return the point.  Corner is named by symbol like either #bottomRight or #bottonRight:."
	cornerName last == $: 
		ifFalse: [^ self perform: cornerName]
		ifTrue: ["don't want to intern a symbol -- too slow!"
			cornerName == #topLeft: ifTrue: [^ self topLeft].
			cornerName == #topRight: ifTrue: [^ self topRight].
			cornerName == #bottomLeft: ifTrue: [^ self bottomLeft].
			cornerName == #bottomRight: ifTrue: [^ self bottomRight].
			cornerName == #center: ifTrue: [^ self center]].
	self error: 'unknown corner name'.

	false ifTrue: ["Selectors Performed"
		"Please list all selectors that could be args to the 
		perform: in this method.  Do this so senders will find
		this method as one of the places the selector is sent from."
		self listPerformSelectorsHere.		"tells the parser its here"

		self bottomRight. self topRight.
		self bottomLeft. self topLeft.
		self center].