windowPreferredCornerStyleFor: aWindow
	"Answer the preferred corner style for the given window."

	^(Preferences roundedWindowCorners or: [
			aWindow cornerStyle == #rounded])
		ifTrue: [#rounded]
		ifFalse: [#square]