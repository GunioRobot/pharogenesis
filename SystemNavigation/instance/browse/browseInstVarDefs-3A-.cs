browseInstVarDefs: aClass
	"Copied from browseInstVarRefs.  Should be consolidated some day. 7/29/96 di
	7/30/96 sw: did the consolidation"
	"Change to use SystemNavigation  27 March 2003 sd"

	aClass chooseInstVarThenDo:	
		[:aVar | self browseAllStoresInto: aVar from: aClass]