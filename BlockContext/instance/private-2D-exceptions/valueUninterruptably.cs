valueUninterruptably
	"Temporarily make my home Context unable to return control to its sender, to guard against circumlocution of the ensured behavior."

	| sendingContext result homeSender |
	sendingContext := thisContext sender sender.
	homeSender _ home swapSender: nil.
	[[result := self
				on: BlockCannotReturn
				do:
					[:ex |
					thisContext unwindTo: sendingContext.
					sendingContext home answer: ex result.
					ex return: ex result]]
						on: ExceptionAboutToReturn
						do:
							[:ex |
							home sender == nil
								ifTrue:
									[home swapSender: homeSender.
									ex resume: homeSender]
								ifFalse: [ex resume: nil]]]
		on: Exception
		do:
			[:ex |
			home swapSender: homeSender.
			ex pass].
	home swapSender: homeSender.
	^result