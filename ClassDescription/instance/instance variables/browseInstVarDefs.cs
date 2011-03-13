browseInstVarDefs 
	"Copied from browseInstVarRefs.  Should be consolidated some day. 7/29/96 di
	7/30/96 sw: did the consolidation"

	self chooseInstVarThenDo:	
		[:aVar | self browseAllStoresInto: aVar]