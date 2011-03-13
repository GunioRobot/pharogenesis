getUserResponse
	"Wait for the user to accept or cancel, and answer the result string. Answers the empty string if the user cancels."
	"Details: This is invoked synchronously from the caller. In order to keep processing inputs and updating the screen while waiting for the user to respond, this method has its own version of the World's event loop."

	| w |
	w _ self world.
	w ifNil: [^ response].
	done _ false.
	[done] whileFalse: [Display doOneCycleMorphic].
	self delete.
	Display doOneCycleMorphic.
	^ response
