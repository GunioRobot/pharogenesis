startOfMessageFromMe

	myForm ifNil: [
		myForm _ EToySenderMorph pictureForIPAddress: NetNameResolver localAddressString.
		myForm ifNotNil: [
			myForm _ myForm scaledToSize: 20@20
		].
	].
	myForm ifNil: [
		^(Preferences defaultAuthorName asText allBold addAttribute: TextColor blue)
	].
	^'*' asText
		addAttribute: (TextAnchor new anchoredMorph: myForm);
		yourself

