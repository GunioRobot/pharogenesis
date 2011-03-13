mouseLeave: evt
	"Reinstate the old border style."

	(self valueOfProperty: #oldBorder)
		ifNotNilDo: [:b |
			self borderStyle: b.
			self removeProperty: #oldBorder]
		ifNil: [self borderNormal]