step
	| cmd |
	"Check for a command that could not be executed in my subproject.  Once it is done, remove the trigger.  If this is too slow, make armsLengthCmd an inst var."

	cmd _ self valueOfProperty: #armsLengthCmd.
	cmd ifNil: [^ super step].
	self removeProperty: #armsLengthCmd.
	(self valueOfProperty: #wasStepping) ifFalse: [
		self stopStepping].
	self removeProperty: #wasStepping.
	project perform: cmd.
	project enter.