updateInOrder: currentTime
	"Update this script assuming that one command runs after the previous command finishes"

	| nextCommand result |

	"Update the previous command if it's still active"
	activeAnimations do: [:anim | anim update: currentTime.
								(anim isDone) ifTrue: [activeAnimations remove: anim ]].

	"Check if all active animations are complete, if not keep pulling and executing script commands until we hit one that doesn't complete immediately"
	(activeAnimations isEmpty)
		ifTrue: [ [ (pendingCommands isEmpty) or: [activeAnimations isEmpty not] ]
					whileFalse: [
						nextCommand _ myCommands at: (pendingCommands removeFirst).

						"evaluate the command in my namespace"
						result _ Compiler new evaluate: nextCommand in: nil to: nil
									notifying: (myWorld getNamespace
												getEvaluationContext) ifFail: [].

						myWorld addOutputText: (result printString).

						(result isKindOf: Animation)
							ifTrue: [ activeAnimations addLast: result ].
								].
				
				((activeAnimations isEmpty) and: [ pendingCommands isEmpty ])
					ifTrue: [ isRunning _ false ].
				].
