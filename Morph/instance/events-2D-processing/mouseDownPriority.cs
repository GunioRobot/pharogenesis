mouseDownPriority
	"Return the default mouse down priority for the receiver"
	(self isPartsDonor or:[self isPartsBin])
		ifTrue:[^50]
		ifFalse:[^0].
	self flag: #workAround.
	"The above is a workaround for the complete confusion between parts donors and parts bins. Morphs residing in a parts bin may or may not have the parts donor property set; if they have they may or may not actually handle events. To work around this, parts bins get an equal priority to parts donors so that when a morph in the parts bin does have the property set but does not handle the event we still get a copy from picking it up through the parts bin. Argh. This just *cries* for a cleanup."