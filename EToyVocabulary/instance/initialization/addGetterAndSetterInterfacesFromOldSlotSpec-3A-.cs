addGetterAndSetterInterfacesFromOldSlotSpec: aCommandSpec
	"Create, given an old etoy-style command spec, appropriate MethodInterfaces, and store those interfaces in my method-interface dictionary"

	| aMethodInterface aSelector |

	aMethodInterface _ MethodInterface new initializeFromEToySlotSpec: aCommandSpec.
	methodInterfaces at:  aCommandSpec seventh put: aMethodInterface.

	(aCommandSpec size >= 9 and: [(#(unused missing) includes: aCommandSpec ninth) not])
		ifTrue:
			[aMethodInterface _ MethodInterface new initializeFor: (aSelector _ aCommandSpec ninth).
			methodInterfaces at: aSelector put: aMethodInterface]

"	1	#slot  -- indicates that is a slot specification rather than a method specification
	2	slot name
	3	help message
	4	type
	5	#readOnly or #readWrite (if #readWrite, items 8 and 9 should be present & meaningful)
	6	<future use -- target for getter -- currently always set to #player>
	7	getter selector
	8	<future use -- target for setter -- currently always set to #player>
	9	setter selector"
