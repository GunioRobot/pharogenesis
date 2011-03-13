getUserResponse
	"Wait for the user to accept or cancel, and answer the result string. Answers the empty string if the user cancels."
	"Details: This is invoked synchronously from the caller. In order to keep processing inputs and updating the screen while waiting for the user to respond, this method has its own version of the World's event loop."

	| w |
	w := self world.
	w ifNil: [^ response].
	
	(ProvideAnswerNotification signal:
		(self findA: TextMorph) userString) ifNotNil:
		[:answer |
		self delete.
		w doOneCycle.
		^ response := (answer == #default) ifTrue: [response] ifFalse: [answer]].

	done := false.
	w activeHand newKeyboardFocus: textPane.
	[done] whileFalse: [w doOneCycle].
	self delete.
	w doOneCycle.
	^ response
