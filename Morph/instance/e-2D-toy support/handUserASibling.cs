handUserASibling
	"Make and hand the user a sibling instance.  Force the creation of a uniclass at this point if one does not already exist for the receiver."

	| topRend |
	topRend _ self topRendererOrSelf.
	topRend assuredPlayer assureUniClass.
	(topRend makeSiblings: 1) first openInHand