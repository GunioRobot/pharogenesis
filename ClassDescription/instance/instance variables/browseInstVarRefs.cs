browseInstVarRefs 
	"1/16/96 sw: moved here from Browser so that it could be used from a variety of places.
	 7/30/96 sw: call chooseInstVarThenDo: to get the inst var choice"

	self chooseInstVarThenDo: 
		[:aVar | self browseAllAccessesTo: aVar]