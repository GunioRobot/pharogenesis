checkForBlockCopy: receiver
	"We just saw a blockCopy: message. Check for a following block."

	| savePc jump args argPos block |
	receiver == constructor codeThisContext ifFalse: [^false].
	savePc := pc.
	(jump := self interpretJump) ifNil:
		[pc := savePc.  ^false].
	self sawBlueBookBlock.
	"Definitely a block"
	jump := jump + pc.
	argPos := statements size.
	[self willStorePop]
		whileTrue:
			[stack addLast: ArgumentFlag.  "Flag for doStore:"
			self interpretNextInstructionFor: self].
	args := Array new: statements size - argPos.
	1 to: args size do:  "Retrieve args"
		[:i | args at: i put: statements removeLast.
		(args at: i) scope: -1  "flag args as block temps"].
	block := self blockTo: jump.
	stack addLast: (constructor codeArguments: args block: block).
	^true