copyToOther
	"Copy this entire change set into the one on the other side"

	"controller controlTerminate."
	| other |
	other _ (parent other: self) changeSet.

	other assimilateAllChangesFoundIn: myChangeSet.
	(parent other: self) launch.
	"controller controlInitialize"