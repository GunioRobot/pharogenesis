resetWhoIfNecessary

	restrictedWho <= 0 ifTrue: [^ self].
	self providePossibleRestrictedView: 0.
