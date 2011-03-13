addHandles 
	| pt handle |
	isCollapsed ifTrue: [^ self "no handles if collapsed"].
	#(topLeft topRight bottomLeft bottomRight rightCenter leftCenter
		topLeft topRight bottomLeft bottomRight topCenter bottomCenter)
		withIndexDo: [:ptName :i | pt _ self bounds perform: ptName.
			handle _ Morph new color: Color gray; extent: (i<=6 ifTrue: [2@20] ifFalse: [20@2]).
			handle align: (handle bounds perform: ptName) with: pt.
			handle on: #mouseEnter send: #enterHandle:morph:pointName:
					to: self withValue: ptName.
			self addMorph: handle].
