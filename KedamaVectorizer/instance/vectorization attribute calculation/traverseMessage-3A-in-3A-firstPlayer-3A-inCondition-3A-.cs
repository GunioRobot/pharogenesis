traverseMessage: aMessageNode in: obj firstPlayer: firstPlayer inCondition: inCondition

	| receiver thisPlayer ret constant proto |

	aMessageNode arguments do: [:argument |
		(argument isMemberOf: MessageNode) ifTrue: [
			self traverseMessage: argument in: obj firstPlayer: firstPlayer inCondition: inCondition.
		].
		(argument isMemberOf: BlockNode) ifTrue: [
			self traverseBlock: argument in: obj firstPlayer: firstPlayer inCondition: inCondition.
		].
		(argument isMemberOf: LiteralNode) ifTrue: [
			attributes setAttribute: #constant of: argument to: true.
		].
		(argument isMemberOf: VariableNode) ifTrue: [
			thisPlayer _ Compiler evaluate: argument name for: obj logged: false.
			ret _ (thisPlayer isKindOf: Player) and: [thisPlayer costume renderedMorph isKindOf: KedamaPatchMorph].
			attributes setAttribute: #constant of: argument to: ret.
		].
	].

	receiver _ aMessageNode receiver.
	(receiver isMemberOf: MessageNode) ifTrue: [
		self traverseMessage: receiver in: obj firstPlayer: firstPlayer inCondition: inCondition.
	].
	(receiver isMemberOf: BlockNode) ifTrue: [
		self traverseBlock: receiver in: obj firstPlayer: firstPlayer inCondition: inCondition.
	].
	(receiver isMemberOf: LiteralNode) ifTrue: [
		attributes setAttribute: #constant of: receiver to: true.
	].
	(receiver isMemberOf: VariableNode) ifTrue: [
		thisPlayer _ Compiler evaluate: receiver name for: obj logged: false.
		ret _ thisPlayer == firstPlayer.
		attributes setAttribute: #constant of: receiver to: ret.
		proto _ (thisPlayer isKindOf: Player) and: [thisPlayer isPrototypeTurtlePlayer].
		attributes setAttribute: #isTurtle of: receiver to: proto.
		attributes setAttribute: #scalar of: aMessageNode selector to:
		(ret not and: [(proto and: [self isScalarizable: thisPlayer andSelector: aMessageNode selector key])]).
	].

	"special cases..."
	(#(atRandom die getReplicated bounceOn: bounceOn:color: bounceOnColor: ifTrue: ifFalse: ifTrue:ifFalse: itFalse:ifTrue:
	setPatchValueIn:to: getTurtleAt: getTurtleOf:) includes: aMessageNode selector key) ifTrue: [
		attributes setAttribute: #constant of: aMessageNode to: false.
		aMessageNode selector key = #die ifTrue: [
			attributes setAttribute: #dieMessage of: root to: true.
		].

	] ifFalse: [
		constant _ (aMessageNode arguments copyWith: receiver) inject: true into: [:s :t | s _ s and: [attributes getAttribute: #constant of: t]].
		attributes setAttribute: #constant of: aMessageNode to: constant.
	].

