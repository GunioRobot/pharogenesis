startAudioChat: toggleMode

	| chat r |

	(self valueOfProperty: #embeddedAudioChatHolder) ifNotNil: [
		toggleMode ifFalse: [^self].
		^self killExistingChat
	].
	(self ownerThatIsA: EToyFridgeMorph) isNil ifTrue: [
		chat _ AudioChatGUI new ipAddress: self ipAddress.
		chat
			removeConnectButton;		"we already know the connectee"
			vResizing: #shrinkWrap;
			hResizing: #shrinkWrap;
			borderWidth: 2.
		r _ (self addARow: {chat}) vResizing: #shrinkWrap.
		self world startSteppingSubmorphsOf: chat.
		self setProperty: #embeddedAudioChatHolder toValue: r.
		self hResizing: #spaceFill; vResizing: #spaceFill.
	] ifFalse: [
		chat _ AudioChatGUI new ipAddress: self ipAddress.
		chat openInWorld: self world.
	]
