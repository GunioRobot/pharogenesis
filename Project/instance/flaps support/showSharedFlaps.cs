showSharedFlaps
	"Answer whether shared flaps are shown or suppressed in this project"

	| result |
	result _ Preferences showSharedFlaps.
	^ self == Project current
		ifTrue:
			[result]
		ifFalse:
			[self projectPreferenceAt: #showSharedFlaps ifAbsent: [result]]