adjustBorderUponActivationWhenLabeless
	"Adjust the border upon, um, activation when, um, labelless"

	| aWidth |
	(aWidth _ self valueOfProperty: #borderWidthWhenActive) ifNotNil:
		[self acquireBorderWidth: aWidth]