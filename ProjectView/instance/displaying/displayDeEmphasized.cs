displayDeEmphasized
	| cmd |
	"Display this view with emphasis off.  Check for a command that
could not be executed in my subproject.  Once it is done, remove the
trigger."

	super displayDeEmphasized.
	ArmsLengthCmd ifNil: [^ self].
	ArmsLengthCmd first == model ifFalse: [^ self].	"not ours"
	cmd _ ArmsLengthCmd second.
	ArmsLengthCmd _ nil.
	model "project" perform: cmd.
	model "project" enter.
