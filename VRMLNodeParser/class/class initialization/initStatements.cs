initStatements
	"VRMLNodeParser initialize"
	VRMLStatements := Dictionary new.
	#(
	DEF
	USE
	PROTO
	EXTERNPROTO
	ROUTE
	Script
	) do:[:sym| VRMLStatements at: sym asString put: ('parse',sym,':') asSymbol]