fromString: authorityString
	| userInfoEnd remainder hostEnd |
	userInfoEnd _ authorityString indexOf: $@.
	remainder _ userInfoEnd > 0
		ifTrue: [
			userInfo _ authorityString copyFrom: 1 to: userInfoEnd-1.
			authorityString copyFrom: userInfoEnd+1 to: authorityString size]
		ifFalse: [authorityString].
	hostEnd _ remainder indexOf: $: .
	hostEnd > 0
		ifTrue: [
			host _ remainder copyFrom: 1 to: hostEnd-1.
			port _ (remainder copyFrom: hostEnd+1 to: remainder size) asNumber]
		ifFalse: [host _ remainder]