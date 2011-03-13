monitorTypeCRTPreferenceChanged
	Preferences MonitorTypeCRT
		ifTrue:[Preferences disable: #MonitorTypeLCD]
		ifFalse:[
			Preferences MonitorTypeLCD
				ifFalse:[
					"turn it back on again"
					^Preferences enable: #MonitorTypeCRT]].
	subPixelAntiAliasing := Preferences MonitorTypeLCD.
	World restoreMorphicDisplay.
	