icon
	"Answer a form with an icon to represent the receiver"
	|o|
	o := self operation.
	o isNil ifTrue: [^MenuIcons smallJumpIcon].
	o isAddition ifTrue: [^MenuIcons smallOkIcon].
	o isRemoval ifTrue: [^MenuIcons smallCancelIcon].
	^MenuIcons smallForwardIcon