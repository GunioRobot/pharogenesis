talkButtonDown

	EToyListenerMorph confirmListening.
	self handsFreeTalking ifFalse: [^self record].
	theTalkButton label: 'Release'.
