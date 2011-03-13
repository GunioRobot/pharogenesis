subtractOtherSide
	"Subtract the changes found on the other side from the requesting side.  3/13/96 sw"

	| other |
	other _ (parent other: self) changeSet.
	myChangeSet forgetAllChangesFoundIn: other.
	self launch