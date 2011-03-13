currentStack
	"Answer the current stack of the current project.  Called basically as a bail-out when we can't find the stack in the owner chain of a morph, probably because it is on a background that is not currently installed.  This method will always return a stack that is in the world, or nil if no stack is found in the world.  Of course it would be nice to have multiple stacks concurrently open in the same world, but at the moment that is problematical."

	| aStack curStack |

	curStack _ self projectParameterAt: #CurrentStack.
	curStack ifNotNil: [curStack isInWorld ifTrue: [^ curStack]].

	(aStack _ world findA: StackMorph) ifNotNil:
		[self currentStack: aStack].
	^ aStack