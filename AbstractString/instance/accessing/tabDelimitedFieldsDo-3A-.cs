tabDelimitedFieldsDo: aBlock
	"Considering the receiver as a holder of tab-delimited fields, evaluate execute aBlock with each field in this string.  The separatilng tabs are not included in what is passed to aBlock"

	| start end |
	"No senders but was useful enough in earlier work that it's retained for the moment."
	start _ 1.
	[start <= self size] whileTrue: 
		[end _ self indexOf: Character tab startingAt: start ifAbsent: [self size + 1].
		end _ end - 1.
		aBlock value: (self copyFrom: start  to: end).
		start _ end + 2]

"
'fred	charlie	elmo		2' tabDelimitedFieldsDo: [:aField | Transcript cr; show: aField]
"