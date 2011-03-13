setClassAndSelectorFrom: messageIDString in: csBlock
	"Decode strings of the form <className> [class] <selectorName>.  Derived from method setClassAndSelectorIn: of class MessageSet.  6/28/96 sw"

	| aStream aClass maybeClass sel |
	aStream _ ReadStream on: messageIDString.
	aClass _ Smalltalk at: (aStream upTo: $ ) asSymbol.
	maybeClass _ aStream upTo: $ .
	sel _ aStream upTo: $ .
	(maybeClass = 'class') & (sel size ~= 0)
		ifFalse: [csBlock value: aClass value: maybeClass asSymbol]
		ifTrue: [csBlock value: aClass class value: sel asSymbol]

"
Utilities setClassAndSelectorFrom: 'Utilities class oppositeModeTo:' in: [:aClass :aSelector | Transcript cr; show: 'Class = ', aClass name printString, ' selector = ', aSelector printString].

Utilities setClassAndSelectorFrom: 'MessageSet setClassAndSelectorIn:' in: [:aClass :aSelector | Transcript cr; show: 'Class = ', aClass name printString, ' selector = ', aSelector printString].
"
