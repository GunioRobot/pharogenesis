delete
	"Delete the halo.  Tell the target that it no longer has the halo; accept any pending edits to the name; and then  actually delete myself"

	target ifNotNil: [target hasHalo: false].
	self acceptNameEdit.
	self isMagicHalo: false.
	super delete.