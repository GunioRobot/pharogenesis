rangesOfAngleBrackets: sourceStrm
	"Return an OrderedCollection of intervals of position within angle brackets < and >.  Caller wants to avoid putting <br> in there."

	| list char intervals start |
	list _ OrderedCollection new: 10.
	[sourceStrm atEnd] whileFalse: [
		(char _ sourceStrm next) == $< ifTrue: [list add: sourceStrm position].	"a start"
		char == $> ifTrue: [list add: sourceStrm position negated]].	"an end"
	sourceStrm reset.
	intervals _ OrderedCollection new: 10.
	start _ nil.
	list do: [:each |
		(each > 0) & (start == nil) ifTrue: [start _ each].
		(each < 0) & (start ~~ nil) ifTrue: [
			intervals add: (start to: each negated). start _ nil]].
	^ intervals	

"	HTMLformatter rangesOfAngleBrackets: (ReadStream on: '1234 <good> <456 <good> 567> <ok>')
	"