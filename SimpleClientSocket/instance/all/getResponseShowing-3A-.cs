getResponseShowing: showFlag
	"Get a the response to the last command, filtering out LF characters. If showFlag is true, each of the response is shown in the upper-left corner of the Display as it is received."

	| response line buf bytesRead c |
	self waitForDataQueryingUserEvery: 15.

	response _ WriteStream on: ''.
	line _ WriteStream on: ''.
	buf _ String new: 1000.
	[self dataAvailable]
		whileTrue: [
			bytesRead _ self receiveDataInto: buf.
			1 to: bytesRead do: [:i |
				(c _ buf at: i) ~= LF
					ifTrue: [
						line nextPut: c.
						response nextPut: c]
					ifFalse: [
						showFlag ifTrue: [
							self displayString: line contents.
							line reset]]]].

	^ response contents
