sharedFlapsSettingChanged
	"The current value of the showSharedFlaps flag has changed; now react"
	self showSharedFlaps
		ifTrue: [self currentWorld addGlobalFlaps]
		ifFalse: ["viz. the new setting"
			Flaps globalFlapTabsIfAny
				do: [:aFlapTab | Flaps removeFlapTab: aFlapTab keepInList: true]]