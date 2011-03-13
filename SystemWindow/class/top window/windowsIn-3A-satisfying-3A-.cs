windowsIn: aWorld satisfying: windowBlock
	^ aWorld submorphs select:
		[:m | (m isKindOf: SystemWindow) and: [windowBlock value: m]]