monitorTypeLCDPreferenceChanged
	Preferences MonitorTypeLCD
		ifTrue:[Preferences disable: #MonitorTypeCRT]
		ifFalse:[
			Preferences MonitorTypeCRT
				ifFalse:[
					"turn it back on again"
					^Preferences enable: #MonitorTypeLCD]].
	subPixelAntiAliasing := Preferences MonitorTypeLCD.
	World restoreMorphicDisplay.