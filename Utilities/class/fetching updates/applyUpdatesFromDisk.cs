applyUpdatesFromDisk
	"Utilities applyUpdatesFromDisk"
	"compute highest update number"
	| updateDirectory updateNumbers |
	updateDirectory _ self getUpdateDirectoryOrNil.
	updateDirectory
		ifNil: [^ self].
	updateNumbers _ updateDirectory fileNames
				collect: [:fn | fn initialIntegerOrNil]
				thenSelect: [:fn | fn notNil].
	self
		applyUpdatesFromDiskToUpdateNumber: (updateNumbers
				inject: 0
				into: [:max :num | max max: num])
		stopIfGap: false