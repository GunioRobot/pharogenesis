recordShapeProperty: id length: length
	(shapes at: id ifAbsent:[^self]) setProperty: #originalFileSize toValue: length