flapTabs
	^ self submorphs select:
		[:m | m isKindOf: FlapTab]