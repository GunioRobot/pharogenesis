nilOrBooleanConstantReceiverOf: sendNode
	"Answer nil or the boolean constant that is the receiver of the given message send. Used to suppress conditional code when the condition is a translation-time constant."

	| rcvr val |
	generateDeadCode ifTrue:[^nil].
	rcvr _ sendNode receiver.
	rcvr isConstant ifTrue: [
		val _ rcvr value.
		((val == true) or: [val == false]) ifTrue: [^ val]].
	^ nil
