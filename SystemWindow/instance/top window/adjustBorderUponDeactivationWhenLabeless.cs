adjustBorderUponDeactivationWhenLabeless
	"Adjust the border upon deactivation when, labelless"

	| aWidth |
	(aWidth _ self valueOfProperty: #borderWidthWhenInactive) ifNotNil:
		[self acquireBorderWidth: aWidth]