start
	"Start running this script"

	| result |

	(scriptType = inOrder)
		ifTrue: [
					pendingCommands _ OrderedCollection new.
					1 to: (myCommands size) do: [:i | pendingCommands addLast: i ].
				]
		ifFalse: [
					myCommands do: [:command | result _ command.
						result _ Compiler new evaluate: command in: nil to: nil
								notifying: (myWorld getNamespace
											getEvaluationContext) ifFail: [].

						myWorld addOutputText: (result printString).

						(result isKindOf: Animation)
							ifTrue: [ activeAnimations add: result ].
									].
				].


	isRunning _ true.

	"Need to add this script to the scheduler so it gets updated"
	myScheduler addUpdateItem: self.

	"Update the script once with the current time"
	self update: (myScheduler getTime).
