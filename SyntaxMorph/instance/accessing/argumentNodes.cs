argumentNodes
	"Return a collection of this message's argument nodes.  "

	| cls coll rec |
	parseNode ifNil: [^ #()].
	cls _ parseNode class.
	cls == SelectorNode ifTrue: [^ #()].
	cls == KeyWordNode ifTrue: [^ #()].

	coll _ OrderedCollection new.
	rec _ self receiverNode.
	submorphs do: [:sub | 
		(sub isSyntaxMorph and: [sub ~~ rec]) ifTrue: [
			sub isNoun ifTrue: [coll addLast: sub]	"complete arg"
				ifFalse: [coll _ coll, sub argumentNodes]]].	"MessagePartNode, MessageNode with no receiver"
	^ coll