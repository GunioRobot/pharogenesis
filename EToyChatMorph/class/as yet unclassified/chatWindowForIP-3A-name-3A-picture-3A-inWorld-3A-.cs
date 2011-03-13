chatWindowForIP: ipAddress name: senderName picture: aForm inWorld: aWorld

	| makeANewOne aSenderBadge existing |

	existing _ self instanceForIP: ipAddress inWorld: aWorld.
	existing ifNotNil: [^existing].
	makeANewOne _ [
		self new
			recipientForm: aForm; 
			open; 
			setIPAddress: ipAddress
	].
	EToyCommunicatorMorph playArrivalSound.
	self doChatsInternalToBadge ifTrue: [
		aSenderBadge _ EToySenderMorph instanceForIP: ipAddress inWorld: aWorld.
		aSenderBadge ifNotNil: [
			aSenderBadge startChat: false.
			^aSenderBadge 
				findDeepSubmorphThat: [ :x | x isKindOf: EToyChatMorph] 
				ifAbsent: makeANewOne
		].
		aSenderBadge _ EToySenderMorph instanceForIP: ipAddress.
		aSenderBadge ifNotNil: [
			aSenderBadge _ aSenderBadge veryDeepCopy.
			aSenderBadge 
				killExistingChat;
				openInWorld: aWorld;
				startChat: false.
			^aSenderBadge 
				findDeepSubmorphThat: [ :x | x isKindOf: EToyChatMorph] 
				ifAbsent: makeANewOne
		].
		(aSenderBadge _ EToySenderMorph new)
			userName: senderName 
			userPicture: aForm
			userEmail: 'unknown' 
			userIPAddress: ipAddress;
			position: 200@200;
			openInWorld: aWorld;
			startChat: false.
		^aSenderBadge 
			findDeepSubmorphThat: [ :x | x isKindOf: EToyChatMorph] 
			ifAbsent: makeANewOne
	].
	^makeANewOne value.

