submit: sendNow

	| newMessageNumber personalCeleste windows |

	personalCeleste _ false.
	celeste ifNil: [
		personalCeleste _ true.
		celeste _ Celeste open.
	].

	newMessageNumber _ celeste queueMessageWithText: (
		self breakLines: self completeTheMessage atWidth: 999
	).
	sendNow ifTrue: [celeste sendMail: {newMessageNumber}].
	personalCeleste ifTrue: [
		windows _ SystemWindow 
			windowsIn: self currentWorld 
			satisfying: [ :each | each model == celeste].
		celeste close.
		windows do: [ :each | each delete].
	].
	self forgetIt.
