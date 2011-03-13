targetWith: evt
	"Some other morph become target of the receiver"
	|  menu newTarget |
	menu _ CustomMenu new.
	self potentialTargets  do: [:m | 
		menu add: (m knownName ifNil:[m class name asString]) action: m].
	newTarget _ menu startUpWithCaption: ( self externalName, ' targets...').
	newTarget ifNil:[^self].
	self target: newTarget.