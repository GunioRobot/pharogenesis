restoreBaseGraphic
	"Restore the receiver's base graphic"

	| aGraphic |
	((aGraphic _ self baseGraphic) notNil and:
				[aGraphic ~= originalForm])
		ifTrue:
			[self form: aGraphic]