startOfMessageFromMe

	myForm ifNil: [
		myForm := EToySenderMorph pictureForIPAddress: NetNameResolver localAddressString.
		myForm ifNotNil: [
			myForm := myForm scaledToSize: 20@20
		].
	].
	myForm ifNil: [
		^(Preferences defaultAuthorName asText allBold addAttribute: TextColor blue)
	].
	^(String value: 1) asText
		addAttribute: (TextAnchor new anchoredMorph: myForm);
		yourself

